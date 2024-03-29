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
    private readonly IWineLabelService _wineLabelService;

    public BottleService(NegoSudDbContext context,
                         ILogger<BottleService> logger,
                         IProducerService producerService,
                         IGrapeService grapeService,
                         IStorageLocationService storageLocationService,
                         IWineLabelService wineLabelService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
        _grapeService = grapeService;
        _storageLocationService = storageLocationService;
        _wineLabelService = wineLabelService;
    }

    //</inheritdoc>  
    public async Task<Bottle?> GetBottleAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
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
            if(bottle.BottleStorageLocations != null)
            {
                foreach (var bottleStorageLocation in bottle.BottleStorageLocations)
                {
                    if (bottleStorageLocation.StorageLocation?.Id != null)
                    {
                        StorageLocation? location = await _storageLocationService.GetStorageLocationAsync(bottleStorageLocation.StorageLocation.Id, includeRelations: false);
                        if (location != null)
                        {
                            bottleStorageLocation.StorageLocation = location;
                            bottleStorageLocation.Bottle = bottle;
                        }
                    }
                }
            }            

            if(bottle.BottleGrapes != null)
            {
                foreach (var bottleGrape in bottle.BottleGrapes)
                {
                    if (bottleGrape.Grape?.Id != null)
                    {
                        Grape? grape = await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id, includeRelations: false);
                        if (grape != null)
                        {
                            bottleGrape.Grape = grape;
                            bottleGrape.Bottle = bottle;
                        }
                    }
                }
            }            

            if(bottle.WineLabel?.Id != null)
            {
                WineLabel? wineLabel = await _wineLabelService.GetWineLabelAsync(bottle.WineLabel.Id, includeRelations: false);
                if(wineLabel != null) 
                {
                    bottle.WineLabel = wineLabel;
                }
            }

            if(bottle.Producer?.Id != null)
            {
                Producer? producer = await _producerService.GetProducerAsync(bottle.Producer.Id, includeRelations: false);
                if(producer != null)
                {
                    bottle.Producer = producer;
                }
            }

            Bottle newBottle = (await _context.Bottles.AddAsync(bottle)).Entity;

            if (bottle.BottleStorageLocations != null)
            {
                await _context.AddRangeAsync(bottle.BottleStorageLocations);
            }

            if (bottle.BottleGrapes != null)
            {
                await _context.AddRangeAsync(bottle.BottleGrapes);
            }

            await _context.SaveChangesAsync();

            return newBottle;
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

            // get the current bottle from db
            Bottle? dbBottle = await this.GetBottleAsync(bottle.Id);

            if (dbBottle != null)
            {

                dbBottle.FullName = bottle.FullName;
                dbBottle.Description = bottle.Description;
                dbBottle.WineLabel = bottle.WineLabel;
                dbBottle.Volume = bottle.Volume;
                dbBottle.Picture = bottle.Picture;
                dbBottle.YearProduced = bottle.YearProduced;
                dbBottle.AlcoholPercentage = bottle.AlcoholPercentage;
                dbBottle.CurrentPrice = bottle.CurrentPrice;


                if (bottle.Producer != null)
                {
                    Producer? producer = await _producerService.GetProducerAsync(bottle.Producer.Id, includeRelations: false);
                    // If we found a producer in the database
                    if (producer != null)
                    {
                        dbBottle.Producer = producer;
                    }
                }


                if (bottle.BottleStorageLocations != null && dbBottle.BottleStorageLocations != null)
                {

                    ICollection<BottleStorageLocation>? dbBottleStorageLocations = dbBottle.BottleStorageLocations.ToList();

                    foreach (BottleStorageLocation BottleStorageLocation in bottle.BottleStorageLocations)
                    {
                        //if the BottleStorageLocation already exists
                        BottleStorageLocation? existingBottleStorageLocation = dbBottleStorageLocations.FirstOrDefault(bl => bl.BottleId == BottleStorageLocation.BottleId && bl.StorageLocationId == BottleStorageLocation.StorageLocationId);

                        if (existingBottleStorageLocation != null)
                        {
                            //update the existing BottleStorageLocation
                            existingBottleStorageLocation.Quantity = BottleStorageLocation.Quantity;
                            _context.Entry(existingBottleStorageLocation).State = EntityState.Modified;
                            dbBottleStorageLocations.Remove(existingBottleStorageLocation);
                        }
                        else
                        {
                            // otherwise, add the new BottleStorageLocation to the current bottle
                            dbBottle.BottleStorageLocations.Add(BottleStorageLocation);
                        }

                    }

                    foreach (BottleStorageLocation BottleStorageLocationToDelete in dbBottleStorageLocations)
                    {
                        dbBottle.BottleStorageLocations.Remove(BottleStorageLocationToDelete);
                    }

                }


                if (bottle.BottleGrapes != null && dbBottle.BottleGrapes != null)
                {

                    ICollection<BottleGrape>? dbBottleGrapes = dbBottle.BottleGrapes.ToList();

                    foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                    {
                        //if the BottleGrape already exists
                        BottleGrape? existingBottleGrape = dbBottleGrapes.FirstOrDefault(bl => bl.BottleId == bottleGrape.BottleId && bl.GrapeId == bottleGrape.GrapeId);

                        if (existingBottleGrape != null)
                        {
                            //update the existing BottleGrape
                            existingBottleGrape.GrapePercentage = bottleGrape.GrapePercentage;
                            _context.Entry(existingBottleGrape).State = EntityState.Modified;
                            dbBottleGrapes.Remove(existingBottleGrape);
                        }
                        else
                        {
                            // otherwise, add the new BottleGrape to the current bottle
                            dbBottle.BottleGrapes.Add(bottleGrape);
                        }

                    }

                    foreach (BottleGrape bottleGrapeToDelete in dbBottleGrapes)
                    {
                        //currentBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                        dbBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                    }

                }


                _context.Entry(dbBottle).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return dbBottle;
            }
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

        return false;
    }
}
