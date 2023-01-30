using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryAsync(int id)
        {
            Country? dbCountry = await _countryService.GetCountryAsync(id);

            if (dbCountry == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Country found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbCountry);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync()
        {
            IEnumerable<Country>? dbCountries = await _countryService.GetCountriesAsync();

            if (dbCountries == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No countries in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbCountries);
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult<Country>> AddCountryAsync(Country country)
        {
            Country? dbCountry = await _countryService.AddCountryAsync(country);

            if (dbCountry == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");
            }

            return StatusCode(StatusCodes.Status201Created, dbCountry);
        }

        [HttpPost("UpdateCountry")]
        public async Task<IActionResult> UpdateCountryAsync(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            Country? dbCountry = await _countryService.UpdateCountryAsync(country);

            if (dbCountry == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Country found for id: {id} - could not update.");
            }

            return StatusCode(StatusCodes.Status200OK, dbCountry);
        }

        [HttpPost("DeleteCountry")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            bool? status = await _countryService.DeleteCountryAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Country found for id: {id} - could not delete");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
