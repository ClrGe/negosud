using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class GrapeService : IGrapeService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger _logger;

    public GrapeService(NegoSudDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc>
    public async Task<Grape?> GetGrapeAsync(int id)
    {
        try
        {
            return await _context.Grapes.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>      
    public async Task<IEnumerable<Grape>?> GetGrapesAsync()
    {
        try
        {
            return await _context.Grapes.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<Grape?> AddGrapeAsync(Grape grape)
    {
        try
        {
            await _context.Grapes.AddAsync(grape);
            await _context.SaveChangesAsync();
            return await _context.Grapes.FirstOrDefaultAsync(x => x.Id == grape.Id);

        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<Grape?> UpdateGrapeAsync(Grape grape)
    {
        try
        {
            _context.Entry(grape).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return grape;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task DeleteGrapeAsync(int id)
    {
        try
        {
            Grape? grape = await _context.Grapes.FindAsync(id);
            if (grape != null)
            {
                _context.Grapes.Remove(grape);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }
    }

    public async Task<IEnumerable<Bottle>?> GetBottlesAsync(int id)
    {
        try
        {
            Grape? grape = await _context.Grapes.FindAsync(id);
            if (grape != null)
            {
                return await _context.Bottles.Include(b => b.BottleGrapes).Where(b => b.Id == id).ToListAsync();
            }

            return Enumerable.Empty<Bottle>();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Debug, ex.ToString());
        }

        return null;
    }
}

