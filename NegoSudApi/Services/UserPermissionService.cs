﻿using System.Security.Claims;
using HeimGuard;
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

        public UserPermissionService(IHttpContextAccessor httpContextAccessor, IPermissionService permissionService, IRoleService roleService)
        {
            _httpContextAccessor = httpContextAccessor;
            _permissionService = permissionService;
            _roleService = roleService;
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

            if(roles.Any(role => role == "Admin"))
            {
                return true;
            }

            foreach(var role in roles) 
            {
                Role? dbRole = await _roleService.GetRoleAsync(role);
                if (dbRole != null)
                {
                    if(dbRole.PermissionRoles.Any(rp => rp.Permission?.Name == permission))
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
