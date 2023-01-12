using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class LocationService : ILocationService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<LocationService> _logger;

    public LocationService(NegoSudDbContext context, ILogger<LocationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc>
    public async Task<Location?> GetLocationAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Locations
                    .Include(l => l.BottleLocations)
                    .ThenInclude(bl => bl.Bottle)
                    .FirstOrDefaultAsync(l => l.Id == id);
            }
            return await _context.Locations.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<IEnumerable<Location>?> GetLocationsAsync()
    {
        try
        {
            return await _context.Locations.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<Location?> AddLocationAsync(Location location)
    {
        try
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return await _context.Locations.FirstOrDefaultAsync(x => x.Id == location.Id);

        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task<Location?> UpdateGrapeAsync(Location location)
    {
        try
        {
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>
    public async Task DeleteLocationAsync(int id)
    {
        try
        {
            Location? location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }
    }
}

