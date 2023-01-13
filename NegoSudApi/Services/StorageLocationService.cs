using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class StorageLocationService : IStorageLocationService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<StorageLocationService> _logger;

    public StorageLocationService(NegoSudDbContext context, ILogger<StorageLocationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc>
    public async Task<StorageLocation?> GetStorageLocationAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.StorageLocations
                    .Include(l => l.BottleStorageLocations)
                    .ThenInclude(bl => bl.Bottle)
                    .FirstOrDefaultAsync(l => l.Id == id);
            }
            return await _context.StorageLocations.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
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
            StorageLocation newLocation = (await _context.StorageLocations.AddAsync(storageLocation)).Entity;
            await _context.SaveChangesAsync();
            return newLocation;
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
            _context.Entry(storageLocation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return storageLocation;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task DeleteStorageLocationAsync(int id)
    {
        try
        {
            StorageLocation? location = await _context.StorageLocations.FindAsync(id);
            if (location != null)
            {
                _context.StorageLocations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }
    }
}

