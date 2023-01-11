using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class RegionService : IRegionService
{

    private readonly NegoSudDbContext _context;
    private readonly ILogger<RegionService> _logger;

    public RegionService(NegoSudDbContext context, ILogger<RegionService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc> 
    public async Task<Region?> GetRegionAsync(int id)
    {
        try
        {
            return await _context.Regions.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<IEnumerable<Region>?> GetRegionsAsync()
    {
        try
        {
            return await _context.Regions.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Region?> AddRegionAsync(Region region)
    {
        try
        {
            await _context.Regions.AddAsync(region);
            var country = region.Country;
             _context.Countries.Attach(country!);
             await _context.SaveChangesAsync();
            return await _context.Regions.FindAsync(region.Id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Region?> UpdateRegionAsync(Region region)
    {
        try
        {
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return region;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<bool?> DeleteRegionAsync(int id)
    {
        try
        {
            Region? regionResult = await _context.Regions.FindAsync(id);
            if (regionResult == null)
            {
                return false;
            }

            _context.Regions.Remove(regionResult);
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

