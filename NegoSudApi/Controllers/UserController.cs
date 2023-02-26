using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController :ControllerBase
{
    private readonly IUserService _userService;
    private readonly SecurePassword _securePassword;

    public UserController(IUserService user, SecurePassword securePassword)
    {
        _userService = user;
        _securePassword = securePassword;
    }

    [Authorize(Policy = RolePermissions.CanGetUser)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        User? dbUser = await _userService.GetUserAsync(id);

        if (dbUser == null) return StatusCode(StatusCodes.Status404NotFound, $"No User found for id: {id}");

        return StatusCode(StatusCodes.Status200OK, dbUser);
    }

    [Authorize(Policy = RolePermissions.CanGetUsers)]
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        IEnumerable<User>? dbCountries = await _userService.GetUsersAsync();

        if (dbCountries == null) return StatusCode(StatusCodes.Status404NotFound, "No users in database");

        return StatusCode(StatusCodes.Status200OK, dbCountries);
    }

    [Authorize(Policy = RolePermissions.CanAddUser)]
    [HttpPost("AddUser")]
    public async Task<ActionResult<User>> AddUserAsync(User user)
    {
        user.Password = _securePassword.Hash(user);
        User? dbUser = await _userService.AddUserAsync(user);

        if (dbUser == null) return StatusCode(StatusCodes.Status404NotFound, $"{user.Email} could not be added.");

        return StatusCode(StatusCodes.Status201Created, dbUser);
    }

    [Authorize(Policy = RolePermissions.CanEditUser)]
    [HttpPost("UpdateUser")]
    public async Task<IActionResult> UpdateUserAsync(int id, User user)
    {
        if (user == null) return BadRequest();
        user.Password = _securePassword.Hash(user);
        User? dbUser = await _userService.UpdateUserAsync(user);

        if (dbUser == null)
            return StatusCode(StatusCodes.Status404NotFound, $"No User found for id: {user.Id} - could not update.");

        return StatusCode(StatusCodes.Status200OK, dbUser);
    }

    [Authorize(Policy = RolePermissions.CanDeleteUser)]
    [HttpPost("DeleteUser")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        bool? status = await _userService.DeleteUserAsync(id);

        if (status == false)
            return StatusCode(StatusCodes.Status404NotFound, $"No User found for id: {id} - could not delete");

        return StatusCode(StatusCodes.Status200OK);
    }
}



