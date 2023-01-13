﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class BottleService : IBottleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<BottleService> _logger;
    private readonly IProducerService _producerService;
    private readonly IGrapeService _grapeService;
    private readonly IStorageLocationService _storageLocationService;

    public BottleService(NegoSudDbContext context,
                         ILogger<BottleService> logger,
                         IProducerService producerService,
                         IGrapeService grapeService,
                         IStorageLocationService storageLocationService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
        _grapeService = grapeService;
        _storageLocationService = storageLocationService;
    }

    //</inheritdoc>  
    public async Task<Bottle?> GetBottleAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Bottles
                    .Include(b => b.Producer)
                    .Include(b => b.BottleStorageLocations)
                    .ThenInclude(bl => bl.StorageLocation)
                    .Include(b => b.BottleGrapes)
                    .ThenInclude(bg => bg.Grape)
                    .FirstOrDefaultAsync(b => b.Id == id);
            }
            return await _context.Bottles.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
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
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<Bottle?> AddBottleAsync(Bottle bottle)
    {
        try
        {
            foreach(var bottleLocation in bottle.BottleStorageLocations)
            {
                if(bottleLocation.StorageLocation?.Id != null)
                {
                    StorageLocation? location = await _storageLocationService.GetStorageLocationAsync(bottleLocation.StorageLocation.Id, includes: false);
                    if (location != null)
                    {
                        bottleLocation.StorageLocation = location;
                        bottleLocation.Bottle = bottle;
                    }
                }                
            }

            foreach (var bottleGrape in bottle.BottleGrapes)
            {
                if (bottleGrape.Grape?.Id != null)
                {
                    Grape? grape = await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id, includes: false);
                    if (grape != null)
                    {
                        bottleGrape.Grape = grape;
                        bottleGrape.Bottle = bottle;
                    }
                }
            }

            if(bottle.Producer?.Id != null)
            {
                Producer? producer = await _producerService.GetProducerAsync(bottle.Producer.Id, includes: false);
                if(producer != null)
                {
                    bottle.Producer = producer;
                }
            }

            await _context.Bottles.AddAsync(bottle);

            await _context.AddRangeAsync(bottle.BottleStorageLocations);

            await _context.AddRangeAsync(bottle.BottleGrapes);

            await _context.SaveChangesAsync();

            return await GetBottleAsync(bottle.Id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
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
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
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
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
}
