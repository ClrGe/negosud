using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityAsync(int id)
        {
            City? dbCity = await _cityService.GetCityAsync(id);

            if (dbCity == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No city found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbCity);
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesAsync()
        {
            IEnumerable<City>? dbCities = await _cityService.GetCitiesAsync();

            if (dbCities == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No cities in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbCities);
        }

        [HttpPost("AddCity")]
        public async Task<ActionResult<City>> AddCityAsync(City City)
        {
            City? dbCity = await _cityService.AddCityAsync(City);

            if (dbCity == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");
            }

            return StatusCode(StatusCodes.Status201Created, dbCity);
        }

        [HttpPost("UpdateCity/{id}")]
        public async Task<IActionResult> UpdateCityAsync(int id, City City)
        {
            if (id != City.Id)
            {
                return BadRequest();
            }

            City? dbCity = await _cityService.UpdateCityAsync(City);

            if (dbCity == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No city found for id: {id} - could not update.");
            }

            return StatusCode(StatusCodes.Status200OK, dbCity);
        }

        [HttpPost("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            bool? status = await _cityService.DeleteCityAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No city found for id: {id} - could not delete");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
