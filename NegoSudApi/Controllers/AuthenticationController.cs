using System.Net;
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
    public Task<ActionResult<User>> Login(User model)
    {
        User? dbUser = _jwtAuthenticationService.Authenticate(model.Email, model.Password);
        if (dbUser != null)
        {
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Email, model.Email)
            };
            string? token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);
            User user = new User()
            {
                Id = dbUser.Id,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Email = dbUser.Email
            };

            Response.Cookies.Append(
            "session",
            token,
            new CookieOptions()
            {
                IsEssential = true,
                HttpOnly = false,
                Secure = false,
                SameSite = SameSiteMode.Lax,
            }
            );
           return Task.FromResult<ActionResult<User>>(Ok(user));
        }
        return Task.FromResult<ActionResult<User>>(Unauthorized());
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<User>> Register(User model)
    {
        var userToAdd = new User
        {
            Email = model.Email,
            Password = model.Password,
            FirstName = model.FirstName,
            LastName = model.LastName,
        };
        
        userToAdd.Password = _securePassword.Hash(userToAdd);
        User? dbUser = await _userService.AddUserAsync(userToAdd);

        if (dbUser == null) return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");

        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Email, dbUser.Email)
        };

        string? token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);

        User response = new User()
        {
            Id = dbUser.Id,
            FirstName = dbUser.FirstName,
            LastName = dbUser.LastName,
            Email = dbUser.Email
        };

        Response.Cookies.Append(
            "session",
            token,
            new CookieOptions()
            {
                IsEssential = true,
                HttpOnly = false,
                Secure = false,
                SameSite = SameSiteMode.Lax,
            }
            );

        return StatusCode(StatusCodes.Status201Created, response);
    }
}