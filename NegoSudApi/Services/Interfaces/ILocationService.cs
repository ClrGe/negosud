using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ILocationService
{
    /// <summary>
    /// Get a Location entity from the database by its id
    /// </summary>
    /// <param name="id">The entity id</param>
    /// <returns></returns>
    public Task<Location?> GetLocationAsync(int id);

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

    /// <summary>
    /// Get an IEnumerable of Bottle entity from the database by their location
    /// </summary>
    /// <param name="id">The Location's id</param>
    /// <returns></returns>
    public Task<IEnumerable<Bottle>?> GetBottlesAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Storage entity from the database by their location
    /// </summary>
    /// <param name="id">The Location's id</param>
    /// <returns></returns>
    public Task<IEnumerable<BottleLocation>?> GetBottleLocationAsync(int id);
}