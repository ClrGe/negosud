using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IProducerService
{

    /// <summary>
    /// Get a Producer entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Country's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Producer with the desired id, or null if it doesn't exist</returns>
    Task<Producer?> GetProducerAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Producers from the database
    /// </summary>
    /// <returns>A collection of Producer</returns>
    Task<IEnumerable<Producer>?> GetProducersAsync();

    /// <summary>
    /// Create a new Producer entity in the database
    /// </summary>
    /// <param name="producer">The entity's model</param>
    /// <returns>A Producer</returns>
    Task<Producer?> AddProducerAsync(Producer producer);

    /// <summary>
    /// Update a Producer entity in the database from a new model
    /// </summary>
    /// <param name="producer">The new entity's model</param>
    /// <returns>A Producer</returns>
    Task<Producer?> UpdateProducerAsync(Producer producer);

    /// <summary>
    /// Delete a Producer entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteProducerAsync(int id);
}