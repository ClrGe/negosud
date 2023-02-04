using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class SupplierService : ISupplierService
{

    private readonly NegoSudDbContext _context;
    private readonly ILogger<SupplierService> _logger;

    public SupplierService(NegoSudDbContext context, ILogger<SupplierService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc> 
    public async Task<Supplier?> GetSupplierAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Suppliers
                    .Include(p => p.BottleSuppliers)
                    .ThenInclude(bs => bs.Bottle)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            return await _context.Suppliers.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }



    public async Task<IEnumerable<Supplier>?> GetSuppliersAsync()
    {
        try
        {
            return await _context.Suppliers.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Supplier?> AddSupplierAsync(Supplier Supplier)
    {
        try
        {
            Supplier newSupplier = (await _context.Suppliers.AddAsync(Supplier)).Entity;

            await _context.SaveChangesAsync();

            return newSupplier;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Supplier?> UpdateSupplierAsync(Supplier Supplier)
    {
        try
        {
            _context.Entry(Supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Supplier;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<bool?> DeleteSupplierAsync(int id)
    {
        try
        {
            Supplier? supplierResult = await _context.Suppliers.FindAsync(id);

            if (supplierResult == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplierResult);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return false;
    }
}