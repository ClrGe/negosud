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
    public async Task<ActionResult<string>> Login(User user)
    {
        var dbUser = _jwtAuthenticationService.Authenticate(user.Email, user.Password);
        if (dbUser != null)
        {
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),                
            };

            Role? userRole = (await _userService.GetUserAsync(dbUser.Id, includeRelations: true)).Role;

            if(userRole != null)
            {
                claims.Add(new(ClaimTypes.Role, userRole?.Name));
            }

            string token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);

            var cookieOptions = new CookieOptions()
            {
                IsEssential = true,
                HttpOnly = false,
                Secure = false,
                SameSite = SameSiteMode.Lax,
            };

            Response.Cookies.Append(
            "session",
            token,
            cookieOptions
            );
            Response.Cookies.Append(
            "user_Id",
            response.Id.ToString(),
            cookieOptions
            );
            return StatusCode(StatusCodes.Status200OK, token);
        }
        return StatusCode(StatusCodes.Status401Unauthorized);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<string>> Register(User user)
    {
        var userToAdd = new User
        {
            Email = user.Email,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
        };
        
        userToAdd.Password = _securePassword.Hash(userToAdd);
        User? dbUser = await _userService.AddUserAsync(userToAdd);

        if (dbUser == null) return StatusCode(StatusCodes.Status404NotFound, $"No match - could not add content.");

        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.Email, dbUser.Email)
        };

        Role? userRole = (await _userService.GetUserAsync(dbUser.Id, includeRelations: true)).Role;

        if (userRole != null)
        {
            claims.Add(new(ClaimTypes.Role, userRole?.Name));
        }

        string? token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);

        User response = new User()
        {
            Id = dbUser.Id,
            FirstName = dbUser.FirstName,
            LastName = dbUser.LastName,
            Email = dbUser.Email,
            Role = userRole,
        };

        var cookieOptions = new CookieOptions()
        {
            IsEssential = true,
            HttpOnly = false,
            Secure = false,
            SameSite = SameSiteMode.Lax,
        };

        Response.Cookies.Append(
        "session",
        token,
        cookieOptions
        );
        Response.Cookies.Append(
        "user_Id",
        response.Id.ToString(),
        cookieOptions
        );
        
        return StatusCode(StatusCodes.Status201Created, response);
    }
}