using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

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

    [Authorize(Policy = RolePermissions.CanGetStorageLocation)]
    [HttpGet("{id}")]
    public async Task<ActionResult<StorageLocation>> GetStorageLocationAsync(int id)
    {
        StorageLocation? dbStorageLocation = await _storageLocationService.GetStorageLocationAsync(id);
        if (dbStorageLocation == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No StorageLocation found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbStorageLocation);
    }

    [Authorize(Policy = RolePermissions.CanGetStorageLocation)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StorageLocation>>> GetStorageLocationsAsync()
    {
        IEnumerable<StorageLocation>? dbStorageLocations = await _storageLocationService.GetStorageLocationsAsync();
        if (dbStorageLocations == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No StorageLocations in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbStorageLocations.ToList());
    }

    [Authorize(Policy = RolePermissions.CanAddStorageLocation)]
    [HttpPost("AddStorageLocation")]
    public async Task<ActionResult<StorageLocation>> AddStorageLocationAsync(StorageLocation storageLocation)
    {
        StorageLocation? dbStorageLocation = await _storageLocationService.AddStorageLocationAsync(storageLocation);
        if (dbStorageLocation == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{storageLocation.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbStorageLocation);
    }

    [Authorize(Policy = RolePermissions.CanEditStorageLocation)]
    [HttpPost("UpdateStorageLocation")]
    public async Task<IActionResult> UpdateStorageLocationAsync(StorageLocation storageLocation)
    {
        if (storageLocation == null)
        {
            return BadRequest();
        }

        StorageLocation? dbStorageLocation = await _storageLocationService.UpdateStorageLocationAsync(storageLocation);
        if (dbStorageLocation == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No StorageLocation found for id: {storageLocation.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbStorageLocation);
    }

    [Authorize(Policy = RolePermissions.CanDeleteStorageLocation)]
    [HttpPost("DeleteStorageLocation")]
    public async Task<IActionResult> DeleteStorageLocationAsync(int id)
    {
        StorageLocation? dbStorageLocation = await _storageLocationService.GetStorageLocationAsync(id);
        if (dbStorageLocation == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No StorageLocation found for id: {id} - could not be deleted");
        }

        await _storageLocationService.DeleteStorageLocationAsync(id);
        return StatusCode(StatusCodes.Status200OK, $"Deleted");
    }

}

