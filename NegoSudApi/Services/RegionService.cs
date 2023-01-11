using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services

{

    public class RegionService : IRegionService

    {

        private readonly NegoSudContext _context;

        public RegionService(NegoSudContext context)
        {
            _context = context;
        }

        public async Task<Region?> GetRegionAsync(int id)

        {
            try
            {
                return await _context.Regions.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Region>?> GetRegionsAsync()

        {
            try
            {
                return await _context.Regions.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Region?> AddRegionAsync(Region region)

        {
            try
            {
                await _context.Regions.AddAsync(region);
                await _context.SaveChangesAsync();
                return await _context.Regions.FindAsync(region.Id);
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

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
                return null; 
            }
        }

        public async Task<bool?> DeleteRegionAsync(Region region)

        {
            try
            {
                Region? regionResult = await _context.Regions.FindAsync(region.Id);

                if (region == null)
                {
                    return false;
                }

                _context.Regions.Remove(region);
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
