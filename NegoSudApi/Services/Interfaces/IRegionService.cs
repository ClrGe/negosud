using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IRegionService
{

    /// <summary>
    /// Get a Region entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Country's id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Region object with the desired id, or null if it doesn't exist</returns>
    Task<Region?> GetRegionAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of Regions from the database
    /// </summary>
    /// <returns>A collection of Region object</returns>
    Task<IEnumerable<Region>?> GetRegionsAsync();

    /// <summary>
    /// Create a new Region entity in the database
    /// </summary>
    /// <param name="region">The entity's model</param>
    /// <returns>A Region object</returns>
    Task<Region?> AddRegionAsync(Region region);

    /// <summary>
    /// Update a Region entity in the database from a new model
    /// </summary>
    /// <param name="region">The new entity's model</param>
    /// <returns>A Region object</returns>
    Task<Region?> UpdateRegionAsync(Region region);

    /// <summary>
    /// Delete a Region entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteRegionAsync(int id);
}