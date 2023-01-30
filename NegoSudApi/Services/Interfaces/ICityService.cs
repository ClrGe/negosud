using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ICityService
{
    /// <summary>
    /// Get a City entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The City's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A City with the desired id, or null if it doesn't exist</returns>
    Task<City?> GetCityAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Cities from the database
    /// </summary>
    /// <returns>A collection of City</returns>
    Task<IEnumerable<City>?> GetCitiesAsync();

    /// <summary>
    /// Create a new City entity in the database
    /// </summary>
    /// <param name="city">The entity's model</param>
    /// <returns>A City</returns>
    Task<City?> AddCityAsync(City city);

    /// <summary>
    /// Update a City entity in the database from a new model
    /// </summary>
    /// <param name="city">The new entity's model</param>
    /// <returns>A City</returns>
    Task<City?> UpdateCityAsync(City city);

    /// <summary>
    /// Delete a City entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteCityAsync(int id);
}