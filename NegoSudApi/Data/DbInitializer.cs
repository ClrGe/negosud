using NegoSudApi.Models;

namespace NegoSudApi.Data;

public class DbInitializer
{
    /// <summary>
    /// Seeds the default permissions and roles in the database.
    /// </summary>
    /// <param name="dbContext"></param>
    public static void SeedPermission(NegoSudDbContext dbContext)
    {
        // Seed Default Permissions
        List<Permission> dbPermissions = dbContext.Permissions.ToList();
        foreach (var perm in RolePermissions.DefaultEmployeePermissions)
        {
            if (!dbPermissions.Any(p => p.Name == perm))
            {
                Permission newPermission = new Permission()
                {
                    Name = perm,
                };
                dbContext.Permissions.Add(newPermission);
            }
        }

        dbContext.SaveChanges();
        // Seed Default Role
        List<Role> dbRoles = dbContext.Roles.ToList();
        foreach (var role in RolePermissions.Roles)
        {
            if (!dbRoles.Any(r => r.Name == role))
            {
                Role newRole = new Role()
                {
                    Name = role,
                };
                var newDbRole = dbContext.Roles.Add(newRole).Entity;
                if (role == RolePermissions.Customer)
                {
                    foreach (var perm in RolePermissions.DefaultCustomerPermissions)
                    {
                        if (!dbContext.PermissionRoles.Any(
                                pr => pr.RoleId == newDbRole.Id && pr.Permission.Name == perm))
                        {
                            PermissionRole newPermissionRole = new PermissionRole()
                            {
                                Role = newDbRole,
                                Permission = dbContext.Permissions.FirstOrDefault(p => p.Name == perm),
                            };
                            dbContext.PermissionRoles.Add(newPermissionRole);
                        }
                    }
                }
                else if (role == RolePermissions.Employee)
                {
                    foreach (var perm in RolePermissions.DefaultEmployeePermissions)
                    {
                        if (!dbContext.PermissionRoles.Any(
                                pr => pr.RoleId == newDbRole.Id && pr.Permission.Name == perm))
                        {
                            PermissionRole newPermissionRole = new PermissionRole()
                            {
                                Role = newDbRole,
                                Permission = dbContext.Permissions.FirstOrDefault(p => p.Name == perm),
                            };
                            dbContext.PermissionRoles.Add(newPermissionRole);
                        }
                    }
                }
            }
        }
        
        dbContext.SaveChanges();
    }
}