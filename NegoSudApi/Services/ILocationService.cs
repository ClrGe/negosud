using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface ILocationService
    {
        public Task<Location?> GetLocation(int locationId);
        public Task<IEnumerable<Location>?> GetLocations();
        public Task<Location?> PostLocation(Location model);
        public Task<Location?> PutLocation(Location model);
        public Task DeleteLocation(int locationId);
        public Task<IEnumerable<Bottle>?> GetBottles(int locationId);
        public Task<IEnumerable<Storage>?> GetStorages(int locationId);
    }
}
