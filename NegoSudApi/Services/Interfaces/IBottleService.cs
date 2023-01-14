using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IBottleService
{

    /// <summary>
    /// Get a Bottle entity from the database by its id, , including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Bottle's id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded</param>
    /// <returns>A Bottle model with the desired id, or null if it doesn't exist</returns>
    Task<Bottle?> GetBottleAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of Bottles from the database
    /// </summary>
    /// <returns>A collection of Bottles model</returns>
    Task<IEnumerable<Bottle>?> GetBottlesAsync();

    /// <summary>
    /// Create a new Bottle entity in the database
    /// </summary>
    /// <param name="bottle">The entity's model</param>
    /// <returns>A Bottle model</returns>
    Task<Bottle?> AddBottleAsync(Bottle bottle);

    /// <summary>
    /// Update a Bottle entity in the database from a new model
    /// </summary>
    /// <param name="bottle">The new entity's model</param>
    /// <returns>A Bottle model</returns>
    Task<Bottle?> UpdateBottleAsync(Bottle bottle);

    /// <summary>
    /// Delete a Bottle entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteBottleAsync(int id);
}