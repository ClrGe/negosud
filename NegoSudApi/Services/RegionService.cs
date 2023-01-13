using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class RegionService : IRegionService
{

    private readonly NegoSudDbContext _context;
    private readonly ILogger<RegionService> _logger;
    private readonly ICountryService _countryService;

    public RegionService(NegoSudDbContext context, ILogger<RegionService> logger, ICountryService countryService)
    {
        _context = context;
        _logger = logger;
        _countryService = countryService;
    }

    //</inheritdoc> 
    public async Task<Region?> GetRegionAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Regions
                    .Include(r => r.Country)
                    .Include(r => r.Producers)
                    .FirstOrDefaultAsync(r => r.Id == id);
            }
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
            Country? country = null;
            if(region.Country?.Id != null)
            {
                country = await _countryService.GetCountryAsync(region.Country.Id, includes: false);
            }
            
            // If we found a country in the database
            if (country != null)
            {
                region.Country = country;
            }
            // If we want to add a new country into the database from the AddRegionForm
            else if (region.Country != null)
            {
                region.Country = await _countryService.AddCountryAsync(region.Country);                
            }

            // Create the region in the database
            Region newRegion = (await _context.Regions.AddAsync(region)).Entity;

            await _context.SaveChangesAsync();

            return newRegion;

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
            if (region.Country?.Id != null)
            {
                Country? country = await _countryService.GetCountryAsync(region.Country.Id, includes: false);
                // If we found a country in the database
                if (country != null)
                {
                    region.Country = country;
                }
                // If we want to add a new country into the database from the AddRegionForm
                else if (region.Country != null)
                {
                    region.Country = await _countryService.AddCountryAsync(region.Country);
                }
            }

            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await GetRegionAsync(region.Id);
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

