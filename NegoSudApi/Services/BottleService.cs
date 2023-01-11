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
    public async Task<Bottle?> AddBottleAsync(Bottle Bottle)
    {
        try
        {
            await _context.Bottles.AddAsync(Bottle);
            await _context.SaveChangesAsync();
            return await _context.Bottles.FindAsync(Bottle.Id); // Auto ID from DB
        }
        catch (Exception ex)
        {
            return null; // An error occured
        }
    }

    //</inheritdoc>  
    public async Task<Bottle?> UpdateBottleAsync(Bottle Bottle)
    {
        try
        {
            _context.Entry(Bottle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Bottle;
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
