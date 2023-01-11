using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IGrapeService
{
    /// <summary>
    /// Get a Grape entity from the database by its id
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    public Task<Grape?> GetGrapeAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Grapes Entities 
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Grape>?> GetGrapesAsync();

    /// <summary>
    /// Create a new Grape entity in the database
    /// </summary>
    /// <param name="grape">The entity's model</param>
    /// <returns></returns>
    public Task<Grape?> AddGrapeAsync(Grape grape);

    /// <summary>
    /// Update a Grape entity in the database
    /// </summary>
    /// <param name="grape">The new entity's model</param>
    /// <returns></returns>
    public Task<Grape?> UpdateGrapeAsync(Grape grape);

    /// <summary>
    /// Delete a Grape entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    public Task DeleteGrapeAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Bottles entities from the database by GrapeID
    /// </summary>
    /// <param name="id">The Grape's id</param>
    /// <returns></returns>
    public Task<IEnumerable<Bottle>?> GetBottlesAsync(int id);
}