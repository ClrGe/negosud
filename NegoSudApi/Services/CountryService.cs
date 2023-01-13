using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class CountryService : ICountryService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<CountryService> _logger;

    public CountryService(NegoSudDbContext context, ILogger<CountryService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc>    
    public async Task<Country?> GetCountryAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Countries
                .Include(c => c.Regions)
                .FirstOrDefaultAsync(c => c.Id == id);
            }

            return await _context.Countries.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>    
    public async Task<IEnumerable<Country>?> GetCountriesAsync()
    {
        try
        {
            return await _context.Countries.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>    
    public async Task<Country?> AddCountryAsync(Country country)
    {
        try
        {
            Country newCountry = (await _context.Countries.AddAsync(country)).Entity;
            await _context.SaveChangesAsync();
            return newCountry;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>    
    public async Task<Country?> UpdateCountryAsync(Country country)
    {
        try
        {
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return country;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>    
    public async Task<bool?> DeleteCountryAsync(int id)
    {
        try
        {
            var dbCountry = await _context.Countries.FindAsync(id);

            if (dbCountry == null)
            {
                return false;
            }

            _context.Countries.Remove(dbCountry);
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
