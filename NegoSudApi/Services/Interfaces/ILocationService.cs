using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ILocationService
{
    /// <summary>
    /// Get a Location entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The entity id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns></returns>
    public Task<Location?> GetLocationAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of Location entities from the database
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Location>?> GetLocationsAsync();

    /// <summary>
    /// Create a new Location entity in the database
    /// </summary>
    /// <param name="location">The model of the entity</param>
    /// <returns></returns>
    public Task<Location?> AddLocationAsync(Location location);

    /// <summary>
    /// Update an entity in the database
    /// </summary>
    /// <param name="location">The new entity's model</param>
    /// <returns></returns>
    public Task<Location?> UpdateGrapeAsync(Location location);

    /// <summary>
    /// Delete a Location entity from the database
    /// </summary>
    /// <param name="id">The entity id</param>
    /// <returns></returns>
    public Task DeleteLocationAsync(int id);
}