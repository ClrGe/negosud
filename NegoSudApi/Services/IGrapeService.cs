using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IGrapeService
    {
        /// <summary>
        /// Get a Grape entity from the database by its id
        /// </summary>
        /// <param name="grapeId">The entity's id</param>
        /// <returns></returns>
        public Task<Grape?> GetGrapeAsync(int grapeId);
        /// <summary>
        /// Get an IEnumerable of Grapes Entities 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Grape>?> GetGrapesAsync();
        /// <summary>
        /// Create a new Grape entity in the database
        /// </summary>
        /// <param name="model">The entity's model</param>
        /// <returns></returns>
        public Task<Grape?> AddGrapeAsync(Grape model);
        /// <summary>
        /// Update a Grape entity in the database
        /// </summary>
        /// <param name="model">The new entity's model</param>
        /// <returns></returns>
        public Task<Grape?> UpdateGrapeAsync(Grape model);
        /// <summary>
        /// Delete a Grape entity from the database
        /// </summary>
        /// <param name="grapeId">The entity's id</param>
        /// <returns></returns>
        public Task DeleteGrapeAsync(int grapeId);
        /// <summary>
        /// Get an IEnumerable of BottleGrapes entities from the database by GrapeID
        /// </summary>
        /// <param name="grapeId">The Grape's id</param>
        /// <returns></returns>
        public Task<IEnumerable<BottleGrape>?> GetBottleGrapesAsync(int grapeId);
        /// <summary>
        /// Get an IEnumerable of Bottles entities from the database by GrapeID
        /// </summary>
        /// <param name="grapeId">The Grape's id</param>
        /// <returns></returns>
        public Task<IEnumerable<Bottle>?> GetBottlesAsync(int grapeId);
    }
}
