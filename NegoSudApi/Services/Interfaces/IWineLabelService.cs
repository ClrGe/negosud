using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces
{
    public interface IWineLabelService
    {


        /// <summary>
        /// Get a WineLabel entity from the database by its id, including or not subobjects and collections
        /// </summary>
        /// <param name="id">The WineLabel's id</param>
        /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded</param>
        /// <returns>A WineLabel with the desired id, or null if it doesn't exist</returns>
        Task<WineLabel?> GetWineLabelAsync(int id, bool includeRelations = true);

        /// <summary>
        /// Get an IEnumerable of WineLabels from the database
        /// </summary>
        /// <returns>A collection of WineLabel</returns>
        Task<IEnumerable<WineLabel>?> GetWineLabelsAsync();

        /// <summary>
        /// Create a new WineLabel entity in the database
        /// </summary>
        /// <param name="wineLabel">The entity's model</param>
        /// <returns>A WineLabel</returns>
        Task<WineLabel?> AddWineLabelAsync(WineLabel wineLabel);

        /// <summary>
        /// Update a WineLabel entity in the database from a new model
        /// </summary>
        /// <param name="wineLabel">The new entity's model</param>
        /// <returns>A WineLabel</returns>
        Task<WineLabel?> UpdateWineLabelAsync(WineLabel wineLabel);

        /// <summary>
        /// Delete a WineLabel entity from the database
        /// </summary>
        /// <param name="id">The entity's id</param>
        /// <returns></returns>
        Task<bool?> DeleteWineLabelAsync(int id);
    }
}
