﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
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

    [Authorize(Policy = RolePermissions.CanGetPermission)]
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

    [Authorize(Policy = RolePermissions.CanGetPermission)]
    [HttpGet]
    public async Task<IActionResult> GetPermissionsAsync()
    {
        var dbPermissions = await _permissionService.GetPermissionsAsync();

        if (dbPermissions == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No Permissions in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermissions);
    }

    [Authorize(Policy = RolePermissions.CanAddPermission)]
    [HttpPost("AddPermission")]
    public async Task<ActionResult<Permission>> AddPermissionAsync(Permission permission)
    {
        Permission? dbPermission = await _permissionService.AddPermissionAsync(permission);

        if (dbPermission == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{permission.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbPermission);
    }

    [Authorize(Policy = RolePermissions.CanEditPermission)]
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
            return StatusCode(StatusCodes.Status204NoContent, $"No Permission found for id: {permission.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbPermission);
    }

    [Authorize(Policy = RolePermissions.CanDeletePermission)]
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

