using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces
{
    public interface IProducerService
    {
        /// <summary>
        /// Get a Producer entity from the database by its id
        /// </summary>
        /// <param name="id">The Country's id</param>
        /// <returns></returns>
        Task<Producer?> GetProducerAsync(int id);

        /// <summary>
        /// Get an IEnumerable of Producers from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Producer>?> GetProducersAsync();

        /// <summary>
        /// Create a new Producer entity in the database
        /// </summary>
        /// <param name="producer">The entity's model</param>
        /// <returns></returns>
        Task<Producer?> AddProducerAsync(Producer producer);

        /// <summary>
        /// Update a Producer entity in the database from a new model
        /// </summary>
        /// <param name="producer">The new entity's model</param>
        /// <returns></returns>
        Task<Producer?> UpdateProducerAsync(Producer producer);

        /// <summary>
        /// Delete a Producer entity from the database
        /// </summary>
        /// <param name="id">The entity's id</param>
        /// <returns></returns>
        Task<bool?> DeleteProducerAsync(int id);
    }
}