using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IBottleService
{

    /// <summary>
    /// Get a Bottle entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Bottle's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Bottle with the desired id, or null if it doesn't exist</returns>
    Task<Bottle?> GetBottleAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Bottles from the database
    /// </summary>
    /// <returns>A collection of Bottle</returns>
    Task<IEnumerable<Bottle>?> GetBottlesAsync();

    /// <summary>
    /// Create a new Bottle entity in the database
    /// </summary>
    /// <param name="bottle">The entity's model</param>
    /// <returns>A Bottle</returns>
    Task<Bottle?> AddBottleAsync(Bottle bottle);

    /// <summary>
    /// Update a Bottle entity in the database from a new model
    /// </summary>
    /// <param name="bottle">The new entity's model</param>
    /// <returns>A Bottle</returns>
    Task<Bottle?> UpdateBottleAsync(Bottle bottle);

    /// <summary>
    /// Delete a Bottle entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteBottleAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bottles"></param>
    /// <returns>int</returns>
    Task<ICollection<Bottle>> MassAddBottleAsync(ICollection<Bottle>? bottles);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bottles"></param>
    /// <returns></returns>
    Task<ICollection<Bottle>> MassUpdateBottleAsync(ICollection<Bottle>? bottles);

}