using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IRegionService
    {
        // return region maching id
        Task<Region?> GetRegionAsync(int id);
        // return * regions
        Task<IEnumerable<Region>?> GetRegionsAsync();
        // add a new region
        Task<Region?> AddRegionAsync(Region author);
        // update existing region
        Task<Region?> UpdateRegionAsync(Region author);
        // delete region matching id
        Task<bool?> DeleteRegionAsync(Region author);
    }
}