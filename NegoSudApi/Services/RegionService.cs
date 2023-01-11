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

        //</inheritdoc> 
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

        //</inheritdoc> 
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

        //</inheritdoc> 
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

        //</inheritdoc> 
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

        //</inheritdoc> 
        public async Task<bool?> DeleteRegionAsync(int id)

        {
            try
            {
                Region? regionResult = await _context.Regions.FindAsync(id);

                if (regionResult == null)
                {
                    return false;
                }

                _context.Regions.Remove(regionResult);
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
