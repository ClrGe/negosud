using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IGrapeService
    {
        public Task<Grape?> GetGrapeAsync(int grapeId);
        public Task<IEnumerable<Grape>?> GetGrapesAsync();
        public Task<Grape?> AddGrapeAsync(Grape model);
        public Task<Grape?> UpdateGrapeAsync(Grape model);
        public Task DeleteGrapeAsync(int grapeId);
        public Task<IEnumerable<BottleGrape>?> GetBottleGrapesAsync(int grapeId);
        public Task<IEnumerable<Bottle>?> GetBottlesAsync(int grapeId);
    }
}
