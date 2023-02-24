using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class SupplierOrderService : ISupplierOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<SupplierOrderService> _logger;
    private readonly ISupplierService _supplierService;
    private readonly IBottleService _bottleService;


    public SupplierOrderService(NegoSudDbContext context,
        ILogger<SupplierOrderService> logger,
        ISupplierService supplierService,
        IBottleService bottleService)
    {
        _context = context;
        _logger = logger;
        _supplierService = supplierService;
        _bottleService = bottleService;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> GetSupplierOrderAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.SupplierOrders
                    .Include(sO => sO.Supplier)
                    .Include(sO => sO.Lines)
                    .ThenInclude(l => l.Bottle)
                    .FirstOrDefaultAsync(cO => cO.Id == id);
            }

            return await _context.SupplierOrders.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<IEnumerable<SupplierOrder>?> GetSupplierOrdersAsync()
    {
        try
        {
            return await _context.SupplierOrders.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> AddSupplierOrderAsync(SupplierOrder supplierOrder)
    {
        try
        {
            if(supplierOrder.Supplier?.Id != null)
            {
                Supplier? dbSupplier = await _supplierService.GetSupplierAsync(supplierOrder.Supplier.Id);
                if (dbSupplier != null)
                {
                    supplierOrder.Supplier = dbSupplier;
                }
            }
            
          
            if(supplierOrder.Lines != null)
            {
                foreach (SupplierOrderLine orderLine in supplierOrder.Lines)
                {
                    if (orderLine.Bottle?.Id == null) continue;
                    Bottle? dbBottle = await _bottleService.GetBottleAsync(orderLine.Bottle.Id, true);
                    if (dbBottle != null)
                    {
                        orderLine.Bottle = dbBottle;
                    }
                }
                
                await _context.AddRangeAsync(supplierOrder.Lines);
            }

            supplierOrder.DeliveryStatus = DeliveryStatus.Pending.GetHashCode();
           
            SupplierOrder newSupplierOrder = (await _context.SupplierOrders.AddAsync(supplierOrder)).Entity;
            
            await _context.SaveChangesAsync();

            return newSupplierOrder;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> UpdateSupplierOrderAsync(SupplierOrder supplierOrder)
    {
        try
        {
            // get the current supplierOrder from db
            SupplierOrder? dbSupplierOrder = await this.GetSupplierOrderAsync(supplierOrder.Id);

            if (dbSupplierOrder != null)
            {
                dbSupplierOrder.Reference = supplierOrder.Reference;
                dbSupplierOrder.Description = supplierOrder.Description;
                dbSupplierOrder.DateOrder = supplierOrder.DateOrder;
                dbSupplierOrder.DateDelivery = supplierOrder.DateDelivery;


                if (supplierOrder.Supplier != null)
                {
                    Supplier? supplier =
                        await _supplierService.GetSupplierAsync(supplierOrder.Supplier.Id, includeRelations: false);
                    // If we found a supplier in the database
                    if (supplier != null)
                    {
                        dbSupplierOrder.Supplier = supplier;
                    }
                }


                if (supplierOrder.Lines != null && dbSupplierOrder.Lines != null)
                {
                    ICollection<SupplierOrderLine>? dbLines = dbSupplierOrder.Lines.ToList();

                    foreach (SupplierOrderLine Line in supplierOrder.Lines)
                    {
                        if (Line.Bottle?.Id != null)
                        {
                            Bottle? bottle =
                                await _bottleService.GetBottleAsync(Line.Bottle.Id, includeRelations: false);
                            if (bottle != null)
                            {
                                Line.Bottle = bottle;
                            }
                        }

                        //if the Line already exists
                        SupplierOrderLine? existingLine = dbLines.FirstOrDefault(l => l.Id == Line.Id);

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
                            // otherwise, add the new Line to the current supplierOrder
                            dbSupplierOrder.Lines.Add(Line);
                        }
                    }

                    foreach (SupplierOrderLine LineToDelete in dbLines)
                    {
                        dbSupplierOrder.Lines.Remove(LineToDelete);
                    }
                }

                _context.Entry(dbSupplierOrder).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return dbSupplierOrder;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<bool?> DeleteSupplierOrderAsync(int id)
    {
        try
        {
            //var dbSupplierOrder = await _context.SupplierOrders.FindAsync(id);
            var dbSupplierOrder = await this.GetSupplierOrderAsync(id, true);

            if (dbSupplierOrder == null)
            {
                return false;
            }

            if (dbSupplierOrder.Lines != null)
            {
                _context.RemoveRange(dbSupplierOrder.Lines);
            }

            _context.SupplierOrders.Remove(dbSupplierOrder);
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