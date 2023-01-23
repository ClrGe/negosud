using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IRoleService
{

    /// <summary>
    /// Get a Role entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Role's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Role with the desired id, or null if it doesn't exist</returns>
    Task<Role?> GetRoleAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Roles from the database
    /// </summary>
    /// <returns>A collection of Role</returns>
    Task<IEnumerable<Role>?> GetRolesAsync();

    /// <summary>
    /// Create a new Role entity in the database
    /// </summary>
    /// <param name="role">The entity's model</param>
    /// <returns>A Role</returns>
    Task<Role?> AddRoleAsync(Role role);

    /// <summary>
    /// Update a Role entity in the database from a new model
    /// </summary>
    /// <param name="role">The new entity's model</param>
    /// <returns>A Role</returns>
    Task<Role?> UpdateRoleAsync(Role role);

    /// <summary>
    /// Delete a Role entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteRoleAsync(int id);
}