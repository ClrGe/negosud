using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services
{
    public class CountryService : ICountryService
    {
        private readonly NegoSudDbContext _context;
        public CountryService(NegoSudDbContext context)
        {
            _context = context;
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
                return null;
            }
        }

        //</inheritdoc>    
        public async Task<Country?> GetCountryAsync(int id)
        {
            try
            {
                return await _context.Countries.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>    
        public async Task<Country?> AddCountryAsync(Country country)
        {
            try
            {
                await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
                return await _context.Countries.FindAsync(country.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
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
                return null; // An error occured
            }
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
                return false;
            }
        }
    }
}
