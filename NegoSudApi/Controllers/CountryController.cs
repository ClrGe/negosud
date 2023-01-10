using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;

namespace NegoSudApi.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetCountriesAsync();

            if (countries == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No countries in database");
            }

            return StatusCode(StatusCodes.Status200OK, countries);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCountry(int id)
        {
            Country? country = await _countryService.GetCountryAsync(id);

            if (country == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No Country found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> AddCountry(Country Country)
        {
            var dbCountry = await _countryService.AddCountryAsync(Country);

            if (dbCountry == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Country.Name} could not be added.");
            }

            return CreatedAtAction("GetCountry", new { id = Country.Id }, Country);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCountry(int id, Country Country)
        {
            if (id != Country.Id)
            {
                return BadRequest();
            }

            Country? dbCountry = await _countryService.UpdateCountryAsync(Country);

            if (dbCountry == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Country.Name} could not be updated.");
            }

            return StatusCode(StatusCodes.Status200OK, dbCountry);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var Country = await _countryService.GetCountryAsync(id);
            bool? status = await _countryService.DeleteCountryAsync(Country);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{Country.Name} could not be deleted");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
