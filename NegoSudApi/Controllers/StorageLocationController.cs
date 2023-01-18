using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StorageLocationController : ControllerBase
    {
        private readonly IStorageLocationService _storageLocationService;

        public StorageLocationController(IStorageLocationService storageLocationService)
        {
            _storageLocationService = storageLocationService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageLocation>> GetStorageLocationAsync(int id)
        {
            StorageLocation? dbStorageLocation = await _storageLocationService.GetStorageLocationAsync(id);
            if (dbStorageLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbStorageLocation);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageLocation>>> GetStorageLocationsAsync()
        {
            IEnumerable<StorageLocation>? dbStorageLocations = await _storageLocationService.GetStorageLocationsAsync();
            if (dbStorageLocations == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbStorageLocations.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<StorageLocation>> AddStorageLocationAsync(StorageLocation storageLocation)
        {
            StorageLocation? dbStorageLocation = await _storageLocationService.AddStorageLocationAsync(storageLocation);
            if (dbStorageLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status201Created, dbStorageLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStorageLocationAsync(int id, StorageLocation storageLocation)
        {
            if (id != storageLocation.Id)
            {
                return BadRequest();
            }

            StorageLocation? dbStorageLocation = await _storageLocationService.UpdateStorageLocationAsync(storageLocation);
            if (dbStorageLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            return StatusCode(StatusCodes.Status200OK, dbStorageLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageLocationAsync(int id)
        {
            StorageLocation? dbStorageLocation = await _storageLocationService.GetStorageLocationAsync(id);
            if (dbStorageLocation == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match for query");
            }
            await _storageLocationService.DeleteStorageLocationAsync(id);
            return StatusCode(StatusCodes.Status200OK, $"Deleted");
        }

    }
}
