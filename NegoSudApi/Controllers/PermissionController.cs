using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermissionAsync(int id)
    {
        Permission? dbPermission = await _permissionService.GetPermissionAsync(id);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No Permission found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermission);
    }

    [HttpGet]
    public async Task<IActionResult> GetPermissionsAsync()
    {
        var dbPermissions = await _permissionService.GetPermissionsAsync();

        if (dbPermissions == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No Permissions found in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermissions);
    }

    [HttpPost("AddPermission")]
    public async Task<ActionResult<Permission>> AddPermissionAsync(Permission permission)
    {
        Permission? dbPermission = await _permissionService.AddPermissionAsync(permission);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"{permission.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbPermission);
    }

    [HttpPost("UpdatePermission/{id}")]
    public async Task<IActionResult> UpdatePermissionAsync(Permission permission)
    {
        if (permission == null)
        {
            return BadRequest();
        }

        Permission? dbPermission = await _permissionService.UpdatePermissionAsync(permission);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No permission found for id: {permission.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermission);
    }

    [HttpPost("DeletePermission/{id}")]
    public async Task<IActionResult> DeletePermissionAsync([FromBody]int id)
    {
        bool? status = await _permissionService.DeletePermissionAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No Permission found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}

