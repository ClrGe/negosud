using Microsoft.AspNetCore.Identity;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class SecurePassword 
{
    /// <summary>
    /// Create a hash password
    /// </summary>
    /// <param name="user">The user info whose password is hashed</param>
    /// <returns>The password hashed</returns>
    public string Hash(User user) => new PasswordHasher<User>().HashPassword(user, user.Password);

    /// <summary>
    /// Make the comparison between the password given and the password hashed in the database
    /// </summary>
    /// <param name="user">User info with hashed password</param>
    /// <param name="password">Password provided</param>
    /// <returns>True if the passwords match otherwise false</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public bool VerifyHash(User user, string password)
    {
        bool verificationResult;
        var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password);
        switch (passwordVerificationResult)
        {
            case PasswordVerificationResult.Failed:
                Console.WriteLine("Password incorrect.");
                verificationResult = false;
                break;

            case PasswordVerificationResult.Success:
                Console.WriteLine("Password ok.");
                verificationResult = true;
                break;

            case PasswordVerificationResult.SuccessRehashNeeded:
                Console.WriteLine("Password ok but should be rehashed and updated.");
                verificationResult = true;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        return verificationResult;
    }
    
}