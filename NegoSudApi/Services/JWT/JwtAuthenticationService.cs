using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NegoSudApi.Data;
using NegoSudApi.Models;

namespace NegoSudApi.Services.JWT;

public class JwtAuthenticationService : IJwtAuthenticationService
{
    private ConfigurationManager _configuration;
    private readonly NegoSudDbContext _context;


    public JwtAuthenticationService(ConfigurationManager configuration, NegoSudDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<ActionResult<string>> Login(string email, string password)
    {
        var user = Authenticate(email, password);

        if (user != null)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, email)
            };
            var token = GenerateToken(_configuration["Jwt:Key"]!, claims);
            return new JsonResult(token);
        }
        
        return $"{StatusCodes.Status400BadRequest},  Username or password is incorrect";
    }

    public string GenerateToken(string secret, List<Claim> claims)
    {

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256Signature
            ),
            Issuer = _configuration["Jwt:Issuer"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);

    }

    public User? Authenticate(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user != null)
            if (user.VerifyHash(password, user.Password))
                return user;

        return user;
    }
}