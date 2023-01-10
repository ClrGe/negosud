using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IGrapeService
    {
        public Task<Grape?> GetGrape(int grapeId);
        public Task<IEnumerable<Grape>?> GetGrapes();
        public Task<Grape?> PostGrape(Grape model);
        public Task<Grape?> PutGrape(Grape model);
        public Task DeleteGrape(int grapeId);
        public Task<IEnumerable<BottleGrape>?> GetBottleGrapes(int grapeId);
        public Task<IEnumerable<Bottle>?> GetBottles(int grapeId);
    }
}
