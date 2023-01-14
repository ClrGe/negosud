using System.Security.Claims;
using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IJwtAuthenticationService
{
    /// <summary>
    /// Generate a token
    /// </summary>
    /// <param name="secret">the key given in the config</param>
    /// <param name="claims">List of claims</param>
    /// <returns>A bearer token</returns>
    public string GenerateToken(string secret, List<Claim> claims);

    /// <summary>
    /// Allow the authentication for a given user
    /// </summary>
    /// <param name="email">User's email</param>
    /// <param name="password">User's password</param>
    /// <returns>True if the user is registered, False otherwise</returns>
    public User? Authenticate(string email, string password);

    /// <summary>
    /// Generate a token
    /// </summary>
    /// <returns>A bearer token</returns>
    public string GenerateRefreshToken();
}