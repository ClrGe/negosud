﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;
using System.Drawing;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace NegoSudApi.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CustomerOrderService> _logger;
    private readonly IBottleService _bottleService;
    private readonly IUserService _userService;

    public CustomerOrderService(NegoSudDbContext context,
                         ILogger<CustomerOrderService> logger,
                         IBottleService bottleService,
                         IUserService userService)
    {
        _context = context;
        _logger = logger;
        _bottleService = bottleService;
        _userService = userService;
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

            if(customerOrder.Lines != null)
            {
                foreach (CustomerOrderLine orderLine in customerOrder.Lines)
                {
                    if (orderLine.Bottle?.Id != null)
                    {
                        Bottle? dbBottle = await _bottleService.GetBottleAsync(orderLine.Bottle.Id, includeRelations: true);
                        if (dbBottle != null)
                        {
                            orderLine.Bottle = dbBottle;
                            orderLine.StorageLocations = FindQuantityAndLocationInStorage(dbBottle, orderLine);
                        }
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
    /// <param name="dbBottle">The bottle in the Database</param>
    /// <param name="orderLine">The line from the order for this bottle</param>
    /// <returns>A Collection of location</returns>
    /// <exception cref="ApplicationException"></exception>
    private List<StorageLocation>? FindQuantityAndLocationInStorage(Bottle dbBottle, CustomerOrderLine orderLine)
    {
        var availableLocations = dbBottle.BottleStorageLocations!
            .Where(bsl => bsl.BottleId == orderLine.Bottle.Id && bsl.Quantity > 0)
            .OrderByDescending(bsl => bsl.Quantity)
            .ToList();

        
        if (availableLocations.Count == 0)
        {
            throw new ApplicationException("Nous n'avons pas cette bouteille en stock");
        }

        var totalQuantity = 0;
        List<StorageLocation>? locationWithBottle = null;
        foreach (var location in availableLocations)
        {
            var quantityToAdd = Math.Min((int) (orderLine.Quantity - totalQuantity), (int) location.Quantity);
            totalQuantity += quantityToAdd;
            if (totalQuantity >= orderLine.Quantity)
            {
                locationWithBottle.Add(location.StorageLocation);
                break;
            }
        }

        return locationWithBottle;
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

                    ICollection<CustomerOrderLine>? dbLines = dbCustomerOrder.Lines.ToList();

                    foreach (CustomerOrderLine Line in customerOrder.Lines)
                    {

                        if (Line.Bottle?.Id != null)
                        {
                            Bottle? bottle = await _bottleService.GetBottleAsync(Line.Bottle.Id, includeRelations: false);
                            if (bottle != null)
                            {
                                Line.Bottle = bottle;
                            }
                        }

                        //if the Line already exists
                        CustomerOrderLine? existingLine = dbLines.FirstOrDefault(l => l.Id == Line.Id);

                        if (existingLine != null)
                        {
                            //update the existing Line
                            existingLine.Bottle = Line.Bottle;
                            existingLine.Quantity = Line.Quantity;
                            _context.Entry(existingLine).State = EntityState.Modified;
                            dbLines.Remove(existingLine);
                        }
                        else
                        {
                            // otherwise, add the new Line to the current customerOrder
                            dbCustomerOrder.Lines.Add(Line);
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
