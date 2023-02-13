using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IJwtAuthenticationService _jwtAuthenticationService;
    private readonly IUserService _userService;
    private readonly SecurePassword _securePassword;
    
    public AuthenticationController(IConfiguration configuration, IJwtAuthenticationService jwtAuthenticationService, IUserService userService, SecurePassword securePassword)
    {
        _configuration = configuration;
        _jwtAuthenticationService = jwtAuthenticationService;
        _userService = userService;
        _securePassword = securePassword;
    }
    
    [HttpPost]
    [Route("Login")]
    public Task<ActionResult<string>> Login(User user)
    {
        var dbUser = _jwtAuthenticationService.Authenticate(user.Email, user.Password);
        if (dbUser != null)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email)
            };
            var token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);
            return Task.FromResult<ActionResult<string>>(Ok(token));
        }
        return Task.FromResult<ActionResult<string>>(Unauthorized());
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<string>> Register(User user)
    {
        var userToAdd = new User
        {
            Email = user.Email,
            Password = user.Email
        };
        
        userToAdd.Password = _securePassword.Hash(userToAdd);
        User? dbUser = await _userService.AddUserAsync(userToAdd);

        if (dbUser == null) return StatusCode(StatusCodes.Status404NotFound, $"No match - could not add content.");

        return StatusCode(StatusCodes.Status201Created, dbUser.Email);
    }
}