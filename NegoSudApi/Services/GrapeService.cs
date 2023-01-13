using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class GrapeService : IGrapeService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<GrapeService> _logger;

    public GrapeService(NegoSudDbContext context, ILogger<GrapeService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc>
    public async Task<Grape?> GetGrapeAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Grapes
                    .Include(g => g.BottleGrapes)
                    .ThenInclude(bg => bg.Bottle)
                    .FirstOrDefaultAsync(g => g.Id == id);
            }
            return await _context.Grapes.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
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
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<Grape?> AddGrapeAsync(Grape grape)
    {
        try
        {
            Grape newGrape = (await _context.Grapes.AddAsync(grape)).Entity;
            await _context.SaveChangesAsync();
            return newGrape;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
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
            _logger.Log(LogLevel.Information, ex.ToString());
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
            _logger.Log(LogLevel.Information, ex.ToString());
        }
    }
}

