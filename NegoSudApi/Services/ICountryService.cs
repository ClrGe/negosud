using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>?> GetCountriesAsync(); // GET ALL Countries
        Task<Country?> GetCountryAsync(int id); // GET Single Country
        Task<Country?> AddCountryAsync(Country author); // POST New Country
        Task<Country?> UpdateCountryAsync(Country author); // PUT Country
        Task<bool?> DeleteCountryAsync(Country author); // DELETE Country
    }
}
