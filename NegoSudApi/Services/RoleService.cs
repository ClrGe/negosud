using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class RoleService : IRoleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<RoleService> _logger;
    private readonly IPermissionService _permissionService;

    public RoleService(NegoSudDbContext context, ILogger<RoleService> logger, IPermissionService permissionService)
    {
        _context = context;
        _logger = logger;
        _permissionService = permissionService;
    }

    // </inheritdoc>
    public async Task<Role?> GetRoleAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Roles
                    .Include(p => p.PermissionRoles)
                    .FirstOrDefaultAsync(p => p.Id == id);
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
    public async Task<Role?> GetRoleAsync(string name, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Roles
                    .Include(p => p.PermissionRoles)
                    .FirstOrDefaultAsync(p => p.Name == name);
            }
            return await _context.Roles.FirstOrDefaultAsync(role => role.Name == name);
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
            if(role.PermissionRoles != null)
            {
                foreach(var rolePermission in role.PermissionRoles)
                {
                    if(rolePermission.Permission?.Name != null)
                    {
                        Permission? dbPermission = await _permissionService.GetPermissionAsync(rolePermission.Permission.Name);
                        if(dbPermission != null)
                        {
                            rolePermission.Permission = dbPermission;
                            rolePermission.Role = role;
                        }
                    }
                }
            }

            await _context.AddAsync(role);

            if (role.PermissionRoles != null)
            {
                await _context.AddRangeAsync(role.PermissionRoles);
            }

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
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return role;
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