using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class RoleService : IRoleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<RoleService> _logger;

    public RoleService(NegoSudDbContext context, ILogger<RoleService> logger)
    {
        _context = context;
        _logger = logger;
    }

    // </inheritdoc>
    public async Task<Role?> GetRoleAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Roles
                    .Include(r => r.Users)
                    .Include(r => r.Permissions)
                    .ThenInclude(p => p.Access)
                    .FirstOrDefaultAsync(r => r.Id == id);
            }
            
            return await _context.Roles.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<IEnumerable<Role>?> GetRolesAsync()
    {
        try
        {
            return await _context.Roles.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<Role?> AddRoleAsync(Role role)
    {
        try
        {
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return await _context.Roles.FindAsync(role.Id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<Role?> UpdateRoleAsync(Role role)
    {
        try
        {
            Role? dbRole = await this.GetRoleAsync(role.Id);
            if (dbRole != null)
            {
                dbRole.Name = role.Name;

                if (role.Permissions != null && dbRole.Permissions != null)
                {
                    ICollection<Permission> dbPermissions = dbRole.Permissions.ToList();
                    foreach (var permission in role.Permissions)
                    {
                        Permission? existingPermission = dbPermissions.FirstOrDefault(p => p.Id == permission.Id);
                        if (existingPermission != null)
                        {
                            existingPermission = permission;
                            _context.Entry(existingPermission).State = EntityState.Modified;
                            dbPermissions.Remove(existingPermission);
                        }
                        else
                        {
                            dbRole.Permissions.Add(permission);
                        }
                    }

                    foreach (var permissionToDelete in dbPermissions)
                    {
                        dbRole.Permissions.Remove(permissionToDelete);
                    }
                }
                _context.Entry(role).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return role;
            }
           
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // </inheritdoc>
    public async Task<bool?> DeleteRoleAsync(int id)
    {
        try
        {
            Role? roleResult = await _context.Roles.FindAsync(id);
            if (roleResult == null)
                return false;

            _context.Roles.Remove(roleResult);
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