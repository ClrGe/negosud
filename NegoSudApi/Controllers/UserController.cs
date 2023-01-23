using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController :ControllerBase
{
    private readonly IUserService _userService;
    private readonly SecurePassword _securePassword;

    public UserController(IUserService user, SecurePassword securePassword)
    {
        _userService = user;
        _securePassword = securePassword;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        User? dbUser = await _userService.GetUserAsync(id);

        if (dbUser == null) return StatusCode(StatusCodes.Status204NoContent, $"No User found for id: {id}");

        return StatusCode(StatusCodes.Status200OK, dbUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetCountriesAsync()
    {
        IEnumerable<User>? dbCountries = await _userService.GetUsersAsync();

        if (dbCountries == null) return StatusCode(StatusCodes.Status204NoContent, "No countries in database");

        return StatusCode(StatusCodes.Status200OK, dbCountries);
    }

    [HttpPost("AddUser")]
    public async Task<ActionResult<User>> AddUserAsync(User user)
    {
        user.Password = _securePassword.Hash(user);
        User? dbUser = await _userService.AddUserAsync(user);

        if (dbUser == null) return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");

        return StatusCode(StatusCodes.Status201Created, dbUser);
    }

    [HttpPost("UpdateUser/{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        user.Password = _securePassword.Hash(user);
        User? dbUser = await _userService.UpdateUserAsync(user);

        if (dbUser == null)
            return StatusCode(StatusCodes.Status204NoContent, $"No User found for id: {id} - could not update.");

        return StatusCode(StatusCodes.Status200OK, dbUser);
    }

    [HttpPost("DeleteUser/{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        bool? status = await _userService.DeleteUserAsync(id);

        if (status == false)
            return StatusCode(StatusCodes.Status204NoContent, $"No User found for id: {id} - could not delete");

        return StatusCode(StatusCodes.Status200OK);
    }
}



