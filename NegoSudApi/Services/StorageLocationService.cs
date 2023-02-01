using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class StorageLocationService : IStorageLocationService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<StorageLocationService> _logger;
    private readonly IGetStorageLocationService _getStorageLocationService;
    private readonly IGetBottleService _getBottleService;

    public StorageLocationService(NegoSudDbContext context,
                                  ILogger<StorageLocationService> logger,
                                  IGetStorageLocationService getStorageLocationService,
                                  IGetBottleService getBottleService)
    {
        _context = context;
        _logger = logger;
        _getStorageLocationService = getStorageLocationService;
        _getBottleService = getBottleService;
    }

    //</inheritdoc>
    public async Task<StorageLocation?> GetStorageLocationAsync(int id, bool includeRelations = true)
    {
        return await _getStorageLocationService.GetStorageLocationAsync(id, includeRelations);
    }

    //</inheritdoc>
    public async Task<IEnumerable<StorageLocation>?> GetStorageLocationsAsync()
    {
        try
        {
            return await _context.StorageLocations.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<StorageLocation?> AddStorageLocationAsync(StorageLocation storageLocation)
    {
        try
        {

            if (storageLocation.BottleStorageLocations != null)
            {
                foreach (BottleStorageLocation bottleStorageLocation in storageLocation.BottleStorageLocations)
                {
                    if (bottleStorageLocation.Bottle?.Id != null)
                    {
                        Bottle? bottle = await _getBottleService.GetBottleAsync(bottleStorageLocation.Bottle.Id, includeRelations: false);
                        if (bottle != null)
                        {
                            bottleStorageLocation.Bottle = bottle;
                            bottleStorageLocation.StorageLocation = storageLocation;
                        }
                    }
                }
            }

            StorageLocation newStorageLocation = (await _context.StorageLocations.AddAsync(storageLocation)).Entity;

            if (storageLocation.BottleStorageLocations != null)
            {
                await _context.AddRangeAsync(storageLocation.BottleStorageLocations);
            }

            await _context.SaveChangesAsync();
            return newStorageLocation;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<StorageLocation?> UpdateStorageLocationAsync(StorageLocation storageLocation)
    {
        try
        {

            StorageLocation? dbStorageLocation = await this.GetStorageLocationAsync(storageLocation.Id, includeRelations: true);

            if (dbStorageLocation != null)
            {
                dbStorageLocation.Name = storageLocation.Name;

            if (storageLocation.BottleStorageLocations != null && dbStorageLocation.BottleStorageLocations != null)
            {

                ICollection<BottleStorageLocation>? dbBottleStorageLocations = dbStorageLocation.BottleStorageLocations.ToList();

                foreach (BottleStorageLocation BottleStorageLocation in storageLocation.BottleStorageLocations)
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
                        // otherwise, add the new BottleStorageLocation to the current storageLocation
                        dbStorageLocation.BottleStorageLocations.Add(BottleStorageLocation);
                    }

                }

                foreach (BottleStorageLocation BottleStorageLocationToDelete in dbBottleStorageLocations)
                {
                    dbStorageLocation.BottleStorageLocations.Remove(BottleStorageLocationToDelete);
                }

            }

            _context.Entry(dbStorageLocation).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            
            return dbStorageLocation;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<bool> DeleteStorageLocationAsync(int id)
    {
        try
        {
            StorageLocation? location = await _context.StorageLocations.FindAsync(id);
            if (location != null)
            {
                _context.StorageLocations.Remove(location);
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

