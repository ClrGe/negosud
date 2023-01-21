using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public class AddressService
    {
        private readonly NegoSudDbContext _context;
        private readonly ILogger<AddressService> _logger;

        public AddressService(NegoSudDbContext context, ILogger<AddressService> logger)
        {
            _context = context;
            _logger = logger;
        }

        //<inheritdoc/>
        public async Task<Address?> GetAddressAsync(int id, bool includeRelations = true)
        {
            try
            {
                if (includeRelations)
                {
                    return await _context.Addresses
                    .Include(c => c.City)
                    .FirstOrDefaultAsync(c => c.Id == id);
                }

                return await _context.Addresses.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        //<inheritdoc/>
        public async Task<IEnumerable<Address>?> GetAddressesAsync()
        {
            try
            {
                return await _context.Addresses.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        //<inheritdoc/>
        public async Task<Address?> AddAddressAsync(Address address)
        {
            try
            {
                Address newAddress = (await _context.Addresses.AddAsync(address)).Entity;
                await _context.SaveChangesAsync();
                return newAddress;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        //<inheritdoc/>
        public async Task<Address?> UpdateAddressAsync(Address address)
        {
            try
            {
                _context.Entry(address).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return address;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        //<inheritdoc/>
        public async Task<bool?> DeleteAddressAsync(int id)
        {
            try
            {
                var dbAddress = await _context.Addresses.FindAsync(id);

                if (dbAddress == null)
                {
                    return false;
                }

                _context.Addresses.Remove(dbAddress);
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
}
