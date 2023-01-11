using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface ILocationService
    {
        /// <summary>
        /// Get a Location entity from the database by its id
        /// </summary>
        /// <param name="locationId">The entity id</param>
        /// <returns></returns>
        public Task<Location?> GetLocationAsync(int locationId);
        /// <summary>
        /// Get an IEnumerable of Location entities from the database
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Location>?> GetLocationsAsync();
        /// <summary>
        /// Create a new Location entity in the database
        /// </summary>
        /// <param name="model">The model of the entity</param>
        /// <returns></returns>
        public Task<Location?> AddLocationAsync(Location model);
        /// <summary>
        /// Update an entity in the database
        /// </summary>
        /// <param name="model">The new entity's model</param>
        /// <returns></returns>
        public Task<Location?> UpdateGrapeAsync(Location model);
        /// <summary>
        /// Delete a Location entity in the database
        /// </summary>
        /// <param name="locationId">The entity id</param>
        /// <returns></returns>
        public Task DeleteLocationAsync(int locationId);
        /// <summary>
        /// Get an IEnumerable of Bottle entity from the database by their location
        /// </summary>
        /// <param name="locationId">The Location's id</param>
        /// <returns></returns>
        public Task<IEnumerable<Bottle>?> GetBottlesAsync(int locationId);
        /// <summary>
        /// Get an IEnumerable of Storage entity from the database by their location
        /// </summary>
        /// <param name="locationId">The Location's id</param>
        /// <returns></returns>
        public Task<IEnumerable<Storage>?> GetStoragesAsync(int locationId);
    }
}
