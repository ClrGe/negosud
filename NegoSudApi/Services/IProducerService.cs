using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IProducerService
    {
        // return producer maching id
        Task<Producer?> GetProducerAsync(int id);
        // return * producers
        Task<IEnumerable<Producer>?> GetProducersAsync();
        // add a new producer
        Task<Producer?> AddProducerAsync(Producer author);
        // update existing producer
        Task<Producer?> UpdateProducerAsync(Producer author);
        // delete producer matching id
        Task<bool?> DeleteProducerAsync(Producer author);
    }
}