using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface IBottleService
    {
        /// <summary>
        /// Get an IEnumerable of Bottles from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Bottle>?> GetBottlesAsync();
        /// <summary>
        /// Get a Bottle entity from the database by its id
        /// </summary>
        /// <param name="id">The Bottle's id</param>
        /// <returns></returns>
        Task<Bottle?> GetBottleAsync(int id);
        /// <summary>
        /// Create a new Bottle entity in the database
        /// </summary>
        /// <param name="model">The entity's model</param>
        /// <returns></returns>
        Task<Bottle?> AddBottleAsync(Bottle model);
        /// <summary>
        /// Update a Bottle entity in the database from a new model
        /// </summary>
        /// <param name="model">The new entity's model</param>
        /// <returns></returns>
        Task<Bottle?> UpdateBottleAsync(Bottle model);
        /// <summary>
        /// Delete a Bottle entity from the database
        /// </summary>
        /// <param name="id">The entity's id</param>
        /// <returns></returns>
        Task<bool?> DeleteBottleAsync(int id);
    }
}
