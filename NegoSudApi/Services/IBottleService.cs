using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IBottleService
    {
        Task<IEnumerable<Bottle>?> GetBottlesAsync(); // GET ALL Bottles
        Task<Bottle?> GetBottleAsync(int id); // GET Single Bottle
        Task<Bottle?> AddBottleAsync(Bottle author); // POST New Bottle
        Task<Bottle?> UpdateBottleAsync(Bottle author); // PUT Bottle
        Task<bool?> DeleteBottleAsync(Bottle author); // DELETE Bottle
    }
}
