using System.Security.Claims;
using HeimGuard;
using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services
{
    public class UserPermissionService : IUserPolicyHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;
        private readonly NegoSudDbContext _context;

        public UserPermissionService(IHttpContextAccessor httpContextAccessor, IPermissionService permissionService, IRoleService roleService, NegoSudDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _permissionService = permissionService;
            _roleService = roleService;
            _context = context;
        }

        private ClaimsPrincipal GetUser()
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;
            if (user == null) throw new ArgumentNullException(nameof(user));

            return user;
        }

        public IEnumerable<string> GetUserRoles()
        {
           var user = GetUser();

            return user
              .Claims.Where(c => c.Type == ClaimTypes.Role)
              .Select(r => r.Value)
              .ToArray();
        }

        public async Task<IEnumerable<string?>> GetUserPermissions()
        {
            var user = GetUser();

            var roles = GetUserRoles();

            string?[] permissions = (await _permissionService.GetPermissionsAsync())
                .Where(permission => permission.PermissionRoles.Any(rp => roles.Contains(rp.Role?.Name)))
                .Select(p => p.Name)
                .ToArray();

            return await Task.FromResult(permissions.Distinct());
        }

        public async Task<bool> HasPermission(string permission)
        {
            var roles = GetUserRoles();

            if(roles.Any(role => role == RolePermissions.Admin))
            {
                return true;
            }

            foreach(var role in roles) 
            {
                Role? dbRole = await _roleService.GetRoleAsync(role);
                if (dbRole != null)
                {
                    if(_context.PermissionRoles.Where(pr => pr.RoleId == dbRole.Id).Include(pr => pr.Permission).Any(rp => rp.Permission.Name == permission))
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
