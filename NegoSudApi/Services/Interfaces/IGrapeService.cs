using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IGrapeService
{
    /// <summary>
    /// Get a Grape entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Grape object with the desired id, or null if it doesn't exist</returns>
    public Task<Grape?> GetGrapeAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of Grapes Entities 
    /// </summary>
    /// <returns>A collection of Grape object</returns>
    public Task<IEnumerable<Grape>?> GetGrapesAsync();

    /// <summary>
    /// Create a new Grape entity in the database
    /// </summary>
    /// <param name="grape">The entity's model</param>
    /// <returns>A Grape object</returns>
    public Task<Grape?> AddGrapeAsync(Grape grape);

    /// <summary>
    /// Update a Grape entity in the database
    /// </summary>
    /// <param name="grape">The new entity's model</param>
    /// <returns>A Grape object</returns>
    public Task<Grape?> UpdateGrapeAsync(Grape grape);

    /// <summary>
    /// Delete a Grape entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    public Task DeleteGrapeAsync(int id);
}