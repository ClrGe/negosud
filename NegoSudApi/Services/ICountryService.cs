using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface ICountryService
    {
        /// <summary>
        /// Get an IEnumerable of Countries from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Country>?> GetCountriesAsync();
        /// <summary>
        /// Get a Country entity from the database by its id
        /// </summary>
        /// <param name="id">The Country's id</param>
        /// <returns></returns>
        Task<Country?> GetCountryAsync(int id);
        /// <summary>
        /// Create a new Country entity in the database
        /// </summary>
        /// <param name="model">The entity's model</param>
        /// <returns></returns>
        Task<Country?> AddCountryAsync(Country model);
        /// <summary>
        /// Update a Country entity in the database from a new model
        /// </summary>
        /// <param name="model">The new entity's model</param>
        /// <returns></returns>
        Task<Country?> UpdateCountryAsync(Country model);
        /// <summary>
        /// Delete a Country entity from the database
        /// </summary>
        /// <param name="id">The entity's id</param>
        /// <returns></returns>
        Task<bool?> DeleteCountryAsync(int id);
    }
}
