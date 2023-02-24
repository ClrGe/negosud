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
    public async Task<Country?> GetCountryAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
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
            Country? dbCountry = await this.GetCountryAsync(country.Id);

            if (dbCountry != null)
            {
                dbCountry.Name = country.Name;

                if (country.Cities != null && dbCountry.Cities != null)
                {
                    ICollection<City> dbCities = dbCountry.Cities.ToList();

                    foreach (City city in country.Cities)
                    {
                        City? existingCity = dbCities.FirstOrDefault(c => c.Id == city.Id);

                        if (existingCity != null)
                        {
                            existingCity = city;
                            _context.Entry(existingCity).State = EntityState.Modified;
                            dbCities.Remove(existingCity);
                        }
                        else
                        {
                            dbCountry.Cities.Add(city);
                        }
                    }
                    
                    foreach (var cityToDelete in dbCities)
                    {
                        dbCountry.Cities.Remove(cityToDelete);
                    }
                }

                if (country.Regions != null && dbCountry.Regions != null)
                {
                    ICollection<Region> dbRegions = dbCountry.Regions.ToList();

                    foreach (Region region in country.Regions)
                    {
                        Region? existingRegion = dbRegions.FirstOrDefault(r => r.Id == region.Id);

                        if (existingRegion != null)
                        {
                            existingRegion = region;
                            _context.Entry(existingRegion).State = EntityState.Modified;
                            dbRegions.Remove(existingRegion);
                        }
                        else
                        {
                            dbCountry.Regions.Add(region);
                        }
                    }

                    foreach (var regionToDelete in dbRegions)
                    {
                        dbCountry.Regions.Remove(regionToDelete);
                    }
                }

                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return country;
            }
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

        return false;
    }

}
