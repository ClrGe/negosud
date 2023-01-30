using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class CityService : ICityService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CityService> _logger;

    public CityService(NegoSudDbContext context, ILogger<CityService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    // </inheritdoc>
    public async Task<City?> GetCityAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Cities
                    .Include(c => c.Addresses)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            return await _context.Cities.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<IEnumerable<City>?> GetCitiesAsync()
    {
        try
        {
            return await _context.Cities.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<City?> AddCityAsync(City city)
    {
        try
        {
            City newCity = (await _context.Cities.AddAsync(city)).Entity;
            await _context.SaveChangesAsync();
            return newCity;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<City?> UpdateCityAsync(City city)
    {
        try
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return city;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<bool?> DeleteCityAsync(int id)
    {
        try
        {
            var dbCity = await _context.Cities.FindAsync(id);

            if (dbCity == null)
            {
                return false;
            }

            _context.Cities.Remove(dbCity);
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