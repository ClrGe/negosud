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
            City? dbCity = await this.GetCityAsync(city.Id);
            if (dbCity != null)
            {
                dbCity.Country = city.Country;
                dbCity.Name = city.Name;
                dbCity.ZipCode = city.ZipCode;

                if (city.Addresses != null && dbCity.Addresses != null)
                {
                    ICollection<Address> dbAddresses = dbCity.Addresses.ToList();

                    foreach (Address address in city.Addresses)
                    {
                        Address? existingAddress = dbAddresses.FirstOrDefault(a => a.Id == address.Id);

                        if (existingAddress != null)
                        {
                            existingAddress = address;
                            _context.Entry(existingAddress).State = EntityState.Modified;
                            dbAddresses.Remove(existingAddress);
                        }
                        else
                        {
                            dbCity.Addresses.Add(address);
                        }
                    }

                    foreach (var addressToDelete in dbAddresses)
                    {
                        dbCity.Addresses.Remove(addressToDelete);
                    }
                } 
                
                _context.Entry(dbCity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return dbCity;
            }
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