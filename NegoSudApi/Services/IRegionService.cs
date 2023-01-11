using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IRegionService
    {
        // return region maching id
        Task<Region?> GetRegion(int id);
        // return * regions
        Task<IEnumerable<Region>?> GetRegions();
        // add a new region
        Task<Region?> AddRegions(Region author);
        // update existing region
        Task<Region?> UpdateRegion(Region author);
        // delete region matching id
        Task<bool?> DeleteRegion(Region author);
    }
}