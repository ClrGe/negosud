using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;


namespace NegoSudApi.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CustomerOrderService> _logger;
    private readonly IBottleService _bottleService;
    private readonly IUserService _userService;
    private readonly IAddressService _addressService;

    public CustomerOrderService(NegoSudDbContext context, ILogger<CustomerOrderService> logger, IBottleService bottleService, IUserService userService, IAddressService addressService)
    {
        _context = context;
        _logger = logger;
        _bottleService = bottleService;
        _userService = userService;
        _addressService = addressService;
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
                User? customer = await _userService.GetUserAsync(customerOrder.Customer.Id);
                if (customer != null)
                {
                    customerOrder.Customer = customer;
                }
            }
            
            if(customerOrder.DeliveryAddress != null )
            {
                Address? dbAddress = await _addressService.GetAddressAsync(customerOrder.DeliveryAddress.Id);
                if (dbAddress != null)
                {
                    customerOrder.DeliveryAddress = dbAddress;
                }
            }

            if(customerOrder.Lines != null)
            {
                foreach (CustomerOrderLine orderLine in customerOrder.Lines)
                {
                    if (orderLine.Bottle?.Id == null) continue;
                    Bottle? dbBottle = await _bottleService.GetBottleAsync(orderLine.Bottle.Id, true);
                    if (dbBottle != null)
                    {
                       orderLine.Bottle = dbBottle;
                       // var toto = GetAvailableLocationsAndQuantities(dbBottle, orderLine);
                       // orderLine.CustomerOrderLineStorageLocations.AddRange(orderLine, toto.Result.Keys);
                    }
                    
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

    /// <summary>
    /// Find the location(s) where the bottle is
    /// </summary>
    /// <param name="bottle">The bottle in the Database</param>
    /// <param name="orderLine">The line from the order for this bottle</param>
    /// <returns>A Collection of location</returns>
    /// <exception cref="ApplicationException"></exception>
    private async Task<Dictionary<StorageLocation, int>?> GetAvailableLocationsAndQuantities(Bottle bottle, CustomerOrderLine orderLine)
    {
        var availableLocations = bottle.BottleStorageLocations!
            .Where(bsl => bsl.BottleId == orderLine.Bottle.Id && bsl.Quantity > 0)
            .OrderByDescending(bsl => bsl.Quantity)
            .ToList();

        var quantityByLocation = new Dictionary<StorageLocation, int>();

        if (availableLocations.Count == 0)
        {
            // TODO : revoir ce message avec lancement d'une commande chez le fournisseur
            throw new ApplicationException("Nous n'avons pas cette bouteille en stock");
        }

        var totalQuantity = 0;
        foreach (var location in availableLocations)
        {
            var quantityToAdd = Math.Min((int) (orderLine.Quantity - totalQuantity), (int) location.Quantity);
            quantityByLocation.Add(location.StorageLocation, quantityToAdd);
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

                        if (line.Bottle?.Id != null)
                        {
                            Bottle? bottle = await _bottleService.GetBottleAsync(line.Bottle.Id, includeRelations: false);
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
                                var newLocationsAndQuantities = GetAvailableLocationsAndQuantities(line.Bottle, line);
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
}
