using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IProducerService
    {
        // return producer maching id
        Task<Producer?> GetProducer(int id);
        // return * producers
        Task<IEnumerable<Producer>?> GetProducers();
        // add a new producer
        Task<Producer?> AddProducer(Producer author);
        // update existing producer
        Task<Producer?> UpdateProducer(Producer author);
        // delete producer matching id
        Task<bool?> DeleteProducer(Producer author);
    }
}