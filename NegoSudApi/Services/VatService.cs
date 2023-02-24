using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class VatService :IVatService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<VatService> _logger;

    public VatService(ILogger<VatService> logger, NegoSudDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <inheritdoc />
    public async Task<VAT?> GetVatAsync(int id)
    {
        try
        {
            return await _context.Vat.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());

        }

        return null;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<VAT>?> GetVaTsAsync()
    {
        try
        {
            return await _context.Vat.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());

        }

        return null;
    }

    /// <inheritdoc />
    public async Task<VAT?> AddVatAsync(VAT vat)
    {
        try
        {
            VAT newVat = (await _context.Vat.AddAsync(vat)).Entity;
            await _context.SaveChangesAsync();
            return newVat;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }
        
        return null;
    }

    /// <inheritdoc />
    public async Task<VAT?> UpdateVatAsync(VAT vat)
    {
        try
        {
            _context.Entry(vat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }
        
        return null;
    }

    /// <inheritdoc />
    public async Task<bool?> DeleteVatAsync(int id)
    {
        try
        {
            var dbVat = await _context.Vat.FindAsync(id);
            if (dbVat != null)
            {
                return false;
            }
            
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