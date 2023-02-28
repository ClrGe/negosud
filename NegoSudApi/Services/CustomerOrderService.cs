﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;
using NuGet.Packaging;


namespace NegoSudApi.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CustomerOrderService> _logger;
    private readonly IBottleService _bottleService;
    private readonly IUserService _userService;
    private readonly IAddressService _addressService;
    private readonly ICityService _cityService;
    private readonly ISupplierOrderService _supplierOrderService;

    public CustomerOrderService(NegoSudDbContext context, ILogger<CustomerOrderService> logger, IBottleService bottleService, IUserService userService, IAddressService addressService, ISupplierOrderService supplierOrderService, ICityService cityService)
    {
        _context = context;
        _logger = logger;
        _bottleService = bottleService;
        _userService = userService;
        _addressService = addressService;
        _supplierOrderService = supplierOrderService;
        _cityService = cityService;
    }

    //</inheritdoc>  
    public async Task<CustomerOrder?> GetCustomerOrderAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.CustomerOrders
                    .Include(cO => cO.Customer)
                    .Include(cO => cO.Lines)
                    .ThenInclude(l => l.Bottle)
                    .Include(co => co.Lines)
                    .ThenInclude(cl => cl.CustomerOrderLineStorageLocations)
                    .FirstOrDefaultAsync(cO => cO.Id == id);
            }
            return await _context.CustomerOrders.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<IEnumerable<CustomerOrder>?> GetOwnCustomerOrdersAsync(int userId, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.CustomerOrders
                    .Include(cO => cO.Customer)
                    .Include(cO => cO.Lines)
                    .ThenInclude(l => l.Bottle)
                    .Include(co => co.Lines)
                    .ThenInclude(cl => cl.CustomerOrderLineStorageLocations)
                    .Where(cO => cO.Customer.Id == userId)
                    .ToListAsync();
            }
            return await _context.CustomerOrders.Include(cO => cO.Customer).Where(cO => cO.Customer.Id == userId).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<IEnumerable<CustomerOrder>?> GetCustomerOrdersAsync()
    {
        try
        {
            return await _context.CustomerOrders.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<CustomerOrder?> AddCustomerOrderAsync(CustomerOrder customerOrder)
    {
        try
        {
            if(customerOrder.Customer?.Id != null)
            {
                User? dbCustomer = await _userService.GetUserAsync(customerOrder.Customer.Id);
                if (dbCustomer != null)
                {
                    customerOrder.Customer = dbCustomer;
                }
            }
            
            if(customerOrder.DeliveryAddress != null )
            {
                Address? dbAddress = await _addressService.GetAddressAsync(customerOrder.DeliveryAddress.Id);
                if (dbAddress != null)
                {
                    customerOrder.DeliveryAddress = dbAddress;
                }
                else
                {
                    City? city = null;
                    if (customerOrder.DeliveryAddress != null)
                    {

                        if (customerOrder.DeliveryAddress.CityId != null && customerOrder.DeliveryAddress.CityId > 0)
                        {
                            city = await _cityService.GetCityAsync((int)customerOrder.DeliveryAddress.CityId, includeRelations: false);

                            if (city != null)
                            {
                                customerOrder.DeliveryAddress.City = city;
                            }
                        }

                    }
                    if (city == null)
                    {
                        customerOrder.DeliveryAddress = null;
                    }

                    customerOrder.DeliveryAddress = null;
                }
            }

            var missingBottle = new List<Bottle>();
            
            if(customerOrder.Lines != null)
            {
                foreach (CustomerOrderLine orderLine in customerOrder.Lines)
                {
                    if (orderLine.Bottle?.Id == null) continue;                    
                   
                    Bottle? dbBottle = await _bottleService.GetBottleAsync((int) orderLine.Bottle.Id, true);
                    
                    if (dbBottle == null) continue;
                        
                    var availableLocations = dbBottle.BottleStorageLocations
                        .Where(bsl => bsl.BottleId == orderLine.Bottle.Id && bsl.Quantity > 0)
                        .OrderByDescending(bsl => bsl.Quantity)
                        .ToList();
                    
                    if (CheckBottleQuantity(dbBottle, availableLocations))
                    {
                        orderLine.Bottle = dbBottle;
                        var availableLocationsAndQuantities = GetAvailableLocationsAndQuantities(dbBottle, orderLine, availableLocations);
                        orderLine.CustomerOrderLineStorageLocations.AddRange(availableLocationsAndQuantities.Result?.Keys);
                        customerOrder.DeliveryStatus = DeliveryStatus.New.GetHashCode();
                    }
                    else
                    {
                        missingBottle.Add(dbBottle);
                        customerOrder.DeliveryStatus = DeliveryStatus.OnHold.GetHashCode();
                    }
                }

                var supplierGroups = missingBottle.GroupBy(bottle => bottle.BottleSuppliers.FirstOrDefault()?.Supplier);
                foreach (var supplierGroup in supplierGroups)
                {
                    var supplierOrderLines = supplierGroup.Select(bottle => new SupplierOrderLine
                    {
                        Quantity = bottle.QuantityMinimumToOrder,
                        BottleId = bottle.Id
                    }).ToList();
                    
                    var supplierOrder = new SupplierOrder
                    {
                        Reference = $"Automatique Commande #{supplierGroup.Key.Id}-{DateTime.Today}",
                        Supplier = supplierGroup.Key,
                        Lines = supplierOrderLines
                    };
                    
                    await _supplierOrderService.AddSupplierOrderAsync(supplierOrder);
                }
                
                await _context.AddRangeAsync(customerOrder.Lines);
            }

            
            
            CustomerOrder newCustomerOrder = (await _context.CustomerOrders.AddAsync(customerOrder)).Entity;

            await _context.SaveChangesAsync();

            return newCustomerOrder;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
    

    //</inheritdoc>  
    public async Task<CustomerOrder?> UpdateCustomerOrderAsync(CustomerOrder customerOrder)
    {
        try
        {
            // get the current customerOrder from db
            CustomerOrder? dbCustomerOrder = await this.GetCustomerOrderAsync(customerOrder.Id);

            if (dbCustomerOrder != null)
            {

                dbCustomerOrder.Reference = customerOrder.Reference;
                dbCustomerOrder.Description = customerOrder.Description;
                dbCustomerOrder.Date_Order = customerOrder.Date_Order;
                dbCustomerOrder.Date_Delivery = customerOrder.Date_Delivery;


                if (customerOrder.Customer != null)
                {
                    User? customer = await _userService.GetUserAsync(customerOrder.Customer.Id);
                    // If we found a customer in the database
                    if (customer != null)
                    {
                        dbCustomerOrder.Customer = customer;
                    }
                }


                if (customerOrder.Lines != null && dbCustomerOrder.Lines != null)
                {

                    ICollection<CustomerOrderLine> dbLines = dbCustomerOrder.Lines.ToList();

                    foreach (CustomerOrderLine line in customerOrder.Lines)
                    {

                        if (line.BottleId != null)
                        {
                            Bottle? bottle = await _bottleService.GetBottleAsync((int) line.BottleId, includeRelations: false);
                            if (bottle != null)
                            {
                                line.Bottle = bottle;
                            }
                        }
                        
                        
                        //if the Line already exists
                        CustomerOrderLine? existingLine = dbLines.FirstOrDefault(l => l.Id == line.Id);

                        if (existingLine != null)
                        {
                            //update the existing Line
                            if ((existingLine.Quantity != line.Quantity || existingLine.Bottle != line.Bottle) && line.Bottle != null)
                            {
                                var availableLocations = line.Bottle.BottleStorageLocations
                                    .Where(bsl => bsl.BottleId == line.BottleId && bsl.Quantity > 0)
                                    .OrderByDescending(bsl => bsl.Quantity)
                                    .ToList();
                                var newLocationsAndQuantities = GetAvailableLocationsAndQuantities(line.Bottle, line, availableLocations);
                                existingLine.Bottle = line.Bottle;
                                // existingLine.Quantity = 
                            }
                            existingLine.Bottle = line.Bottle;
                            existingLine.Quantity = line.Quantity;
                            _context.Entry(existingLine).State = EntityState.Modified;
                            dbLines.Remove(existingLine);
                        }
                        else
                        {
                            // otherwise, add the new Line to the current customerOrder
                            dbCustomerOrder.Lines.Add(line);
                        }

                    }

                    foreach (CustomerOrderLine LineToDelete in dbLines)
                    {
                        dbCustomerOrder.Lines.Remove(LineToDelete);
                    }

                }

                _context.Entry(dbCustomerOrder).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return dbCustomerOrder;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<bool?> DeleteCustomerOrderAsync(int id)
    {
        try
        {
            //var dbCustomerOrder = await _context.CustomerOrders.FindAsync(id);
            var dbCustomerOrder = await this.GetCustomerOrderAsync(id,true);

            if (dbCustomerOrder == null)
            {
                return false;
            }

            if (dbCustomerOrder.Lines != null)
            {
                _context.RemoveRange(dbCustomerOrder.Lines);
            }
            
            _context.CustomerOrders.Remove(dbCustomerOrder);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
    
    /// <summary>
    /// Checks if there is enough quantity of a given bottle to fulfill a customer order line.
    /// </summary>
    /// <param name="bottle">The bottle being checked.</param>
    /// <param name="availableLocations">The available locations where the bottle is stored.</param>
    /// <returns>True if there is enough quantity of the bottle to fulfill the customer order line, false otherwise.</returns>
    private bool CheckBottleQuantity(Bottle bottle, List<BottleStorageLocation>? availableLocations)
    {
        var quantityTotalBottle = bottle.BottleStorageLocations.Sum(b => b.Quantity);

        return availableLocations.Count != 0 && !(quantityTotalBottle <= bottle.ThresholdToOrder);
    }


    /// <summary>
    /// Find the location(s) where the bottle is
    /// </summary>
    /// <param name="bottle">The bottle in the Database</param>
    /// <param name="orderLine">The line from the order for this bottle</param>
    /// <param name="availableLocations">List of all location where the bottle is in quantity enough for the order</param>
    /// <returns>A Collection of location</returns>
    private async Task<Dictionary<CustomerOrderLineStorageLocation, int>?> GetAvailableLocationsAndQuantities(Bottle bottle, CustomerOrderLine orderLine, List<BottleStorageLocation>? availableLocations)
    {
        var quantityByLocation = new Dictionary<CustomerOrderLineStorageLocation, int>();

        var totalQuantity = 0;
        foreach (var location in availableLocations)
        {
            var quantityToAdd = Math.Min((int) (orderLine.Quantity - totalQuantity), (int) location.Quantity);
            CustomerOrderLineStorageLocation customerOrderLineStorageLocation = new CustomerOrderLineStorageLocation
            {
                StorageLocation = location.StorageLocation,
                CustomerOrderLine = orderLine
            };
            quantityByLocation.Add(customerOrderLineStorageLocation, quantityToAdd);
            totalQuantity += quantityToAdd;
            if (totalQuantity >= orderLine.Quantity)
            {
                // Update the quantity of the BottleStorageLocation entity in the database
                location.Quantity -= quantityToAdd;
                await _bottleService.UpdateBottleAsync(bottle);
                await _context.SaveChangesAsync();
                break;
            }
        }

        return quantityByLocation;
    }
}
