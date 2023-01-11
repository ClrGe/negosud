using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            IEnumerable<Location>? locations = await _locationService.GetLocationsAsync();
            if (locations == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, locations.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationAsync(int locationId)
        {
            Location? location = await _locationService.GetLocationAsync(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocationAsync(Location model)
        {
            Location? location = await _locationService.AddLocationAsync(model);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrapeAsync(int locationId, Location model)
        {
            if (locationId != model.Id)
            {
                return BadRequest();
            }

            Location? location = await _locationService.UpdateGrapeAsync(model);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync(int locationId)
        {
            Location? location = await _locationService.GetLocationAsync(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            await _locationService.DeleteLocationAsync(locationId);
            return StatusCode(StatusCodes.Status200OK, $"Deleted");
        }

        [HttpGet("bottles/{id}")]
        public async Task<IActionResult> GetBottlesAsync(int locationId)
        {
            Location? location = await _locationService.GetLocationAsync(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            IEnumerable<Bottle>? bottles = await _locationService.GetBottlesAsync(locationId);
            if (bottles == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, bottles);
        }

        [HttpGet("bottleLocations/{id}")]
        public async Task<IActionResult> GetBottleLocationsAsync(int locationId)
        {
            Location? location = await _locationService.GetLocationAsync(locationId);
            if (location == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            IEnumerable<BottleLocation>? storages = await _locationService.GetBottleLocationAsync(locationId);
            if (storages == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, storages);
        }


    }
}
