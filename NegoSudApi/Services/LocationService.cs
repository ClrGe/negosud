﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly NegoSudContext _context;
        public LocationService(NegoSudContext context)
        {
            _context = context;
        }

        //</inheritdoc>
        public async Task<Location?> GetLocationAsync(int locationId)
        {
            try
            {
                return await _context.Locations.FindAsync(locationId);
            }
            catch (Exception ex)
            {
                return null;
            }
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
                return null;
            }
        }

        //</inheritdoc>
        public async Task<Location?> AddLocationAsync(Location model)
        {
            try
            {
                await _context.Locations.AddAsync(model);
                await _context.SaveChangesAsync();
                return await _context.Locations.FirstOrDefaultAsync(x => x.Id == model.Id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>
        public async Task<Location?> UpdateGrapeAsync(Location model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>
        public async Task DeleteLocationAsync(int locationId)
        {
            try
            {
                Location? location = await _context.Locations.FindAsync(locationId);
                if (location != null)
                {
                    _context.Locations.Remove(location);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //</inheritdoc>
        public async Task<IEnumerable<Bottle>?> GetBottlesAsync(int locationId)
        {
            try
            {
                Location? location = await _context.Locations.FindAsync(locationId);
                if (location != null)
                {
                    return await _context.Bottles.Where(x => x.Inventory.Locations.Contains(location)).ToListAsync();
                }
                else
                {
                    return Enumerable.Empty<Bottle>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>
        public async Task<IEnumerable<Storage>?> GetStoragesAsync(int locationId)
        {
            try
            {
                Location? location = await _context.Locations.FindAsync(locationId);
                if(location != null)
                {
                    return await _context.Inventories.Where(x => x.Location_Id== location.Id).ToListAsync();
                }
                else
                {
                    return Enumerable.Empty<Storage>();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
