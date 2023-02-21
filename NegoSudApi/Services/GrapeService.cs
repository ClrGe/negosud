using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class GrapeService : IGrapeService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<GrapeService> _logger;
    private readonly IGetBottleService _getBottleService;

    public GrapeService(NegoSudDbContext context, ILogger<GrapeService> logger, IGetBottleService getBottleService)
    {
        _context = context;
        _logger = logger;
        _getBottleService = getBottleService;
    }

    //</inheritdoc>
    public async Task<Grape?> GetGrapeAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
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
            Grape? dbGrape = await this.GetGrapeAsync(grape.Id);

            if (dbGrape != null)
            {
                dbGrape.GrapeType = grape.GrapeType;

                if (dbGrape.BottleGrapes != null && grape.BottleGrapes != null)
                {
                    ICollection<BottleGrape> dbBottleGrapes = dbGrape.BottleGrapes.ToList();

                    foreach (BottleGrape bottleGrape in grape.BottleGrapes)
                    {
                        BottleGrape? existingBottleGrape = dbBottleGrapes.FirstOrDefault(bg =>
                            bg.GrapeId == bottleGrape.GrapeId && bg.BottleId == bottleGrape.BottleId);
                        if (existingBottleGrape != null)
                        {
                            //update the existing BottleGrape
                            existingBottleGrape.GrapePercentage = bottleGrape.GrapePercentage;
                            _context.Entry(existingBottleGrape).State = EntityState.Modified;
                            dbBottleGrapes.Remove(existingBottleGrape);
                        }
                        else
                        {
                            if (bottleGrape.Bottle?.Id != null)
                            {
                                Bottle? bottle = await _getBottleService.GetBottleAsync(bottleGrape.Bottle.Id, includeRelations: false);
                                if (bottle != null)
                                {
                                    bottleGrape.Grape = grape;
                                    bottleGrape.Bottle = bottle;
                                }
                            }
                            // otherwise, add the new BottleGrape to the current bottle
                            dbGrape.BottleGrapes.Add(bottleGrape);
                        }
                    }

                    foreach (var bottleGrapeToDelete in dbBottleGrapes)
                    {
                        dbGrape.BottleGrapes.Remove(bottleGrapeToDelete); 
                    }
                }
                _context.Entry(grape).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return grape;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<bool> DeleteGrapeAsync(int id)
    {
        try
        {
            Grape? grape = await _context.Grapes.FindAsync(id);
            if (grape != null)
            {
                _context.Grapes.Remove(grape);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return false;
    }
}

