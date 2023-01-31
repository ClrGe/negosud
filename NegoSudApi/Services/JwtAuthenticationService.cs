using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

//</inheritdoc>
public class JwtAuthenticationService : IJwtAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly NegoSudDbContext _context;
    private readonly SecurePassword _securePassword;

    public JwtAuthenticationService(IConfiguration configuration, NegoSudDbContext context, SecurePassword securePassword)
    {
        _configuration = configuration;
        _context = context;
        _securePassword = securePassword;
    }
    
    //</inheritdoc>
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

        var securityToken = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

    }

    //</inheritdoc>
    public User? Authenticate(string email, string password)
    {
        var dbUser = _context.Users.FirstOrDefault(u => u.Email ==  email);

        if (dbUser != null)
            if (_securePassword.VerifyHash(dbUser, password))
                return dbUser;

        return dbUser;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }
}