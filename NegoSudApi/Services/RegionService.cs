using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services

{

    public class RegionService : IRegionService

    {

        private readonly NegoSudDbContext _context;

        public RegionService(NegoSudDbContext context)
        {
            _context = context;
        }

        public async Task<Region?> GetRegion(int id)

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

        public async Task<IEnumerable<Region>?> GetRegions()

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

        public async Task<Region?> AddRegions(Region region)

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

        public async Task<Region?> UpdateRegion(Region region)

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

        public async Task<bool?> DeleteRegion(Region region)

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
