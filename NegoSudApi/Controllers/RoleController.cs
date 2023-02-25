using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController :ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService role)
    {
        _roleService = role;
    }

    [Authorize(Policy = RolePermissions.CanGetRole)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleAsync(int id)
    {
        Role? dbRole = await _roleService.GetRoleAsync(id);

        if (dbRole == null) return StatusCode(StatusCodes.Status404NotFound, $"No Role found for id: {id}");

        return StatusCode(StatusCodes.Status200OK, dbRole);
    }

    [Authorize(Policy = RolePermissions.CanGetRole)]
    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        IEnumerable<Role>? dbCountries = await _roleService.GetRolesAsync();

        if (dbCountries == null) return StatusCode(StatusCodes.Status404NotFound, "No roles in database");

        return StatusCode(StatusCodes.Status200OK, dbCountries);
    }

    [Authorize(Policy = RolePermissions.CanAddRole)]
    [HttpPost("AddRole")]
    public async Task<ActionResult<Role>> AddRoleAsync(Role role)
    {
        Role? dbRole = await _roleService.AddRoleAsync(role);

        if (dbRole == null) return StatusCode(StatusCodes.Status404NotFound, $"{role.Name} could not be added.");

        return StatusCode(StatusCodes.Status201Created, dbRole);
    }

    [Authorize(Policy = RolePermissions.CanEditRole)]
    [HttpPost("UpdateRole")]
    public async Task<IActionResult> UpdateRoleAsync(Role role)
    {
        if (role == null) return BadRequest();
        Role? dbRole = await _roleService.UpdateRoleAsync(role);

        if (dbRole == null)
            return StatusCode(StatusCodes.Status404NotFound, $"No Country found for id: {role.Id} - could not update.");

        return StatusCode(StatusCodes.Status200OK, dbRole);
    }

    [Authorize(Policy = RolePermissions.CanDeleteRole)]
    [HttpPost("DeleteRole")]
    public async Task<IActionResult> DeleteRoleAsync(int id)
    {
        bool? status = await _roleService.DeleteRoleAsync(id);

        if (status == false)
            return StatusCode(StatusCodes.Status404NotFound, $"No Role found for id: {id} - could not delete");

        return StatusCode(StatusCodes.Status200OK);
    }
}



