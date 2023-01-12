using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ICountryService
{

    /// <summary>
    /// Get a Country entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Country's id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns></returns>
    Task<Country?> GetCountryAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of Countries from the database
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Country>?> GetCountriesAsync();

    /// <summary>
    /// Create a new Country entity in the database
    /// </summary>
    /// <param name="country">The entity's model</param>
    /// <returns></returns>
    Task<Country?> AddCountryAsync(Country country);

    /// <summary>
    /// Update a Country entity in the database from a new model
    /// </summary>
    /// <param name="country">The new entity's model</param>
    /// <returns></returns>
    Task<Country?> UpdateCountryAsync(Country country);

    /// <summary>
    /// Delete a Country entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteCountryAsync(int id);
}