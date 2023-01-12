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
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationAsync(int id)
        {
            Location? dbLocation = await _locationService.GetLocationAsync(id);
            if (dbLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbLocation);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsAsync()
        {
            IEnumerable<Location>? dbLocations = await _locationService.GetLocationsAsync();
            if (dbLocations == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbLocations.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocationAsync(Location location)
        {
            Location? dbLocation = await _locationService.AddLocationAsync(location);
            if (dbLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrapeAsync(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            Location? dbLocation = await _locationService.UpdateGrapeAsync(location);
            if (dbLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, location);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync(int id)
        {
            Location? dbLocation = await _locationService.GetLocationAsync(id);
            if (dbLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            await _locationService.DeleteLocationAsync(id);
            return StatusCode(StatusCodes.Status200OK, $"Deleted");
        }

    }
}
