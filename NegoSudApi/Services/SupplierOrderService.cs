using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;
using System.Drawing;

namespace NegoSudApi.Services;

public class SupplierOrderService : ISupplierOrderService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<SupplierOrderService> _logger;
    private readonly IProducerService _producerService;

    public SupplierOrderService(NegoSudDbContext context,
                         ILogger<SupplierOrderService> logger,
                         IProducerService producerService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
    }

    //</inheritdoc>  
    public async Task<SupplierOrder?> GetSupplierOrderAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.SupplierOrders
                    .Include(sO => sO.Producer)
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
      
            if(supplierOrder.Producer?.Id != null)
            {
                Producer? producer = await _producerService.GetProducerAsync(supplierOrder.Producer.Id, includeRelations: false);
                if(producer != null)
                {
                    supplierOrder.Producer = producer;
                }
            }

            SupplierOrder newSupplierOrder = (await _context.SupplierOrders.AddAsync(supplierOrder)).Entity;

            if (supplierOrder.Lines != null)
            {
                await _context.AddRangeAsync(supplierOrder.Lines);
            }

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
                dbSupplierOrder.Date_Order = supplierOrder.Date_Order;
                dbSupplierOrder.Date_Delivery = supplierOrder.Date_Delivery;


                if (supplierOrder.Producer != null)
                {
                    Producer? producer = await _producerService.GetProducerAsync(supplierOrder.Producer.Id, includeRelations: false);
                    // If we found a producer in the database
                    if (producer != null)
                    {
                        dbSupplierOrder.Producer = producer;
                    }
                }


                if (supplierOrder.Lines != null && dbSupplierOrder.Lines != null)
                {

                    ICollection<SupplierOrderLine>? dbLines = dbSupplierOrder.Lines.ToList();

                    foreach (SupplierOrderLine Line in supplierOrder.Lines)
                    {
                        //if the Line already exists
                        SupplierOrderLine? existingLine = dbLines.FirstOrDefault(l => l.SupplierOrder?.Id == Line.SupplierOrder?.Id);

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
            var dbSupplierOrder = await _context.SupplierOrders.FindAsync(id);

            if (dbSupplierOrder == null)
            {
                return false;
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
