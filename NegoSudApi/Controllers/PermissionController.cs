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
            return StatusCode(StatusCodes.Status204NoContent, $"No Permission found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermission);
    }

    [HttpGet]
    public async Task<IActionResult> GetPermissionsAsync()
    {
        var dbPermissions = await _permissionService.GetPermissionsAsync();

        if (dbPermissions == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No Permissions" +
                " in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermissions);
    }

    [HttpPost("Permission")]
    public async Task<ActionResult<Permission>> AddPermissionAsync(Permission permission)
    {
        Permission? dbPermission = await _permissionService.AddPermissionAsync(permission);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{permission.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbPermission);
    }

    [HttpPost("UpdatePermission/{id}")]
    public async Task<IActionResult> UpdatePermissionAsync(int id, Permission permission)
    {
        if (id != permission.Id)
        {
            return BadRequest();
        }

        Permission? dbPermission = await _permissionService.UpdatePermissionAsync(permission);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No match for query - could not update");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermission);
    }

    [HttpPost("DeletePermission/{id}")]
    public async Task<IActionResult> DeletePermissionAsync(int id)
    {
        bool? status = await _permissionService.DeletePermissionAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Permission found for id: {id} - could not be deleted");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}

