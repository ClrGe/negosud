using System.Xml.Linq;
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
    public async Task<User?> GetUserAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Users
                    .Include(u => u.Role)
                    .Include(u => u.Addresses)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }
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
            if(user.Role?.Id != null)
            {
                Role? role = await _roleService.GetRoleAsync(user.Role.Id);
                if(role != null)
                {
                    user.Role = role;
                }
                
            }

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
            User? dbUser = await GetUserAsync(user.Id, includeRelations: true);
            if (dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Email = user.Email;
                dbUser.Password = user.Password;
                dbUser.RefreshToken = user.RefreshToken;
                dbUser.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;

                if(user.Role != null)
                {
                    Role? role = await _roleService.GetRoleAsync(user.Role.Id);
                    if(role != null)
                    {
                        dbUser.Role = role;
                    }
                }

                _context.Entry(dbUser).State = EntityState.Modified;
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