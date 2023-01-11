using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class LocationService : ILocationService
{
    private readonly NegoSudDbContext _context;

    public LocationService(NegoSudDbContext context)
    {
        _context = context;
    }

    //</inheritdoc>
    public async Task<Location?> GetLocationAsync(int id)
    {
        try
        {
            return await _context.Locations.FindAsync(id);
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
            return null;
        }
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
            return null;
        }
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

        }
    }

    //</inheritdoc>
    public async Task<IEnumerable<Bottle>?> GetBottlesAsync(int id)
    {
        try
        {
            Location? location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                return await _context.Bottles.Include(x => x.BottleLocations).Where(x => x.Id == id)
                    .ToListAsync(); // TODO : Refaire les includes
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
    public async Task<IEnumerable<BottleLocation>?> GetBottleLocationAsync(int id)
    {
        throw new NotImplementedException();
        //try
        //{
        //    Location? location = await _context.Locations.FindAsync(locationId);
        //    if(location != null)
        //    {
        //        return await _context.Inventories.Where(x => x.Location_Id== location.Id).ToListAsync();
        //    }
        //    else
        //    {
        //        return Enumerable.Empty<Storage>();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }
}

