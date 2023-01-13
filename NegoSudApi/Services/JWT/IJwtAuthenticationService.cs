using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;

namespace NegoSudApi.Services.JWT;

public interface IJwtAuthenticationService
{
    public ActionResult<string> Login(string email, string password);
    
    public string GenerateToken(string secret, List<Claim> claims);

    public User? Authenticate(string email, string password);
}