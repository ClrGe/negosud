using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NegoSudApi.DTO;
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
    public Task<ActionResult<AuthResponse>> Login(Register register)
    {
        User? dbUser = _jwtAuthenticationService.Authenticate(register.Email, register.Password);
        if (dbUser != null)
        {
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Email, register.Email)
            };
            string? token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);
            AuthResponse response = new AuthResponse()
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
           return Task.FromResult<ActionResult<AuthResponse>>(Ok(response));
        }
        return Task.FromResult<ActionResult<AuthResponse>>(Unauthorized());
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<AuthResponse>> Register(Register register)
    {
        var userToAdd = new User
        {
            Email = register.Email,
            Password = register.Password,
            FirstName = register.FirstName,
            LastName = register.LastName,
        };
        
        userToAdd.Password = _securePassword.Hash(userToAdd);
        User? dbUser = await _userService.AddUserAsync(userToAdd);

        if (dbUser == null) return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");

        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Email, dbUser.Email)
        };

        string? token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);

        AuthResponse response = new AuthResponse()
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