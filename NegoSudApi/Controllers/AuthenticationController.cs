using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IJwtAuthenticationService _jwtAuthenticationService;


    public AuthenticationController(IConfiguration configuration, IJwtAuthenticationService jwtAuthenticationService)
    {
        _configuration = configuration;
        _jwtAuthenticationService = jwtAuthenticationService;
    }
    
    [HttpPost]
    [Route("login")]
    public Task<ActionResult<string>> Login(string email, string password)
    {
        var dbUser = _jwtAuthenticationService.Authenticate(email, password);
        if (dbUser != null)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, email)
            };
            var token = _jwtAuthenticationService.GenerateToken(_configuration["Jwt:Key"]!, claims);
            return Task.FromResult<ActionResult<string>>(Ok(token));
        }
        return Task.FromResult<ActionResult<string>>(Unauthorized());
    }
}