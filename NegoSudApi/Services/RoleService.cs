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
                    .ThenInclude(pr => pr.Permission)
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
            Role? dbRole = await this.GetRoleAsync(role.Id);
            if (dbRole != null)
            {
                dbRole.Name = role.Name;

                if (role.PermissionRoles != null && dbRole.PermissionRoles != null)
                {
                    ICollection<PermissionRole> dbPermissionRoles = dbRole.PermissionRoles.ToList();
                    foreach (var permissionRole in role.PermissionRoles)
                    {
                        PermissionRole? existingPermissionRole = dbPermissionRoles.FirstOrDefault(p => p.PermissionId == permissionRole.PermissionId && p.RoleId == permissionRole.RoleId);
                        if (existingPermissionRole != null)
                        {
                            existingPermissionRole.Permission = permissionRole.Permission;
                            _context.Entry(existingPermissionRole).State = EntityState.Modified;
                            dbPermissionRoles.Remove(existingPermissionRole);
                        }
                        else
                        {
                            if (permissionRole.Permission?.Id != null)
                            {
                                Permission? dbPermission =
                                    await _context.Permissions.FindAsync(permissionRole.Permission?.Id);
                                if (dbPermission != null)
                                {
                                    permissionRole.Permission = dbPermission;
                                    permissionRole.Role = dbRole;
                                }
                            }
                            
                            dbRole.PermissionRoles.Add(permissionRole);
                        }
                    }

                    foreach (var permissionRoleToDelete in dbPermissionRoles)
                    {
                        dbRole.PermissionRoles.Remove(permissionRoleToDelete);
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