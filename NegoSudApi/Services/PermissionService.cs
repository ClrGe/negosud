using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class PermissionService : IPermissionService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<PermissionService> _logger;

    public PermissionService(NegoSudDbContext context, ILogger<PermissionService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    // </inheritdoc
    public async Task<Permission?> GetPermissionAsync(int id)
    {
        try
        {
            return await _context.Permissions.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<IEnumerable<Permission>?> GetPermissionsAsync()
    {
        try
        {
            return await _context.Permissions.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc
    public async Task<Permission?> AddPermissionAsync(Permission permission)
    {
        try
        {
            Permission newPermission = (await _context.Permissions.AddAsync(permission)).Entity;
            await _context.SaveChangesAsync();
            return newPermission;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc
    public async Task<Permission?> UpdatePermissionAsync(Permission permission)
    {
        try
        {
            _context.Entry(permission).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return permission;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }
        
        return null;
    }

    // </inheritdoc
    public async Task<bool?> DeletePermissionAsync(int id)
    {
        try
        {
            var dbPermission = await _context.Permissions.FindAsync(id);

            if (dbPermission == null)
            {
                return false;
            }

            _context.Permissions.Remove(dbPermission);
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