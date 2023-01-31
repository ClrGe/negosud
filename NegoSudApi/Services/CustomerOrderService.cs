using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;
using System.Drawing;

namespace NegoSudApi.Services;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CustomerOrderService> _logger;
    private readonly IBottleService _bottleService;
    //pryivate readonly ICustomerService _customerService;

    public CustomerOrderService(NegoSudDbContext context,
                         ILogger<CustomerOrderService> logger,
                         IBottleService bottleService) //,ICustomerService customerService)
    {
        _context = context;
        _logger = logger;
        _bottleService = bottleService;
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
                //Customer? customer = await _customerService.GetcustomerAsync(customerOrder.Customer.Id, includeRelations: false);
                //if(customer != null)
                //{
                //    customerOrder.Customer = customer;
                //}
            }

            if(customerOrder.Lines != null)
            {
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
                }
            }

            CustomerOrder newCustomerOrder = (await _context.CustomerOrders.AddAsync(customerOrder)).Entity;

            if (customerOrder.Lines != null)
            {
                await _context.AddRangeAsync(customerOrder.Lines);
            }

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
                    //Customer? customer = await _customerService.GetCustomerAsync(customerOrder.Customer.Id, includeRelations: false);
                    //// If we found a customer in the database
                    //if (customer != null)
                    //{
                    //    dbCustomerOrder.Customer = customer;
                    //}
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
