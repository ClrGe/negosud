using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class UserService : IUserService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<UserService> _logger;
    private readonly IRoleService _roleService;

    public UserService(NegoSudDbContext context, ILogger<UserService> logger, IRoleService roleService)
    {
        _context = context;
        _logger = logger;
        _roleService = roleService;
    }

    // </inheritdoc>
    public async Task<User?> GetUserAsync(int id)
    {
        try
        {
            return await _context.Users.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<IEnumerable<User>?> GetUsersAsync()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<User?> AddUserAsync(User user)
    {
        try
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return await _context.Users.FindAsync(user.Id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<User?> UpdateUserAsync(User user)
    {
        try
        {
            User? dbUser = await this.GetUserAsync(user.Id);
            if (dbUser != null)
            {
                dbUser.Email = user.Email;
                dbUser.Password = user.Password;
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.RefreshToken = user.RefreshToken;
                dbUser.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

                if (user.Role != null)
                {
                    Role? dbRole = await _roleService.GetRoleAsync(user.Role.Id);
                }

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return user;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<bool?> DeleteUserAsync(int id)
    {
        try
        {
            User? userResult = await _context.Users.FindAsync(id);
            if (userResult == null)
                return false;

            _context.Users.Remove(userResult);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return false;
    }
}