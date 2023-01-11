using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class BottleService : IBottleService
{
    private readonly NegoSudDbContext _context;

    public BottleService(NegoSudDbContext context)
    {
        _context = context;
    }

    //</inheritdoc>  
    public async Task<IEnumerable<Bottle>?> GetBottlesAsync()
    {
        try
        {
            return await _context.Bottles.ToListAsync();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    //</inheritdoc>  
    public async Task<Bottle?> GetBottleAsync(int id)
    {
        try
        {
            return await _context.Bottles.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    //</inheritdoc>  
    public async Task<Bottle?> AddBottleAsync(Bottle bottle)
    {
        try
        {
            await _context.Bottles.AddAsync(bottle);
            await _context.SaveChangesAsync();
            return await _context.Bottles.FindAsync(bottle.Id); // Auto ID from DB
        }
        catch (Exception ex)
        {
            return null; // An error occured
        }
    }

    //</inheritdoc>  
    public async Task<Bottle?> UpdateBottleAsync(Bottle bottle)
    {
        try
        {
            _context.Entry(bottle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return bottle;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    //</inheritdoc>  
    public async Task<bool?> DeleteBottleAsync(int id)
    {
        try
        {
            var dbBottle = await _context.Bottles.FindAsync(id);

            if (dbBottle == null)
            {
                return false;
            }

            _context.Bottles.Remove(dbBottle);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
