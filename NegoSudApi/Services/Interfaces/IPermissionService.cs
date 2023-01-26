using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IPermissionService
{
    /// <summary>
    /// Get an Permission entity from the database by its id, , including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Permission's id</param>
    /// <returns>An Permission with the desired id, or null if it doesn't exist</returns>
    Task<Permission?> GetPermissionAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Permissions from the database
    /// </summary>
    /// <returns>A collection of Permission</returns>
    Task<IEnumerable<Permission>?> GetPermissionsAsync();

    /// <summary>
    /// Create a new Permission entity in the database
    /// </summary>
    /// <param name="permission">The entity's model</param>
    /// <returns>An Permission</returns>
    Task<Permission?> AddPermissionAsync(Permission permission);

    /// <summary>
    /// Update an Permission entity in the database from a new model
    /// </summary>
    /// <param name="permission">The new entity's model</param>
    /// <returns>An Permission</returns>
    Task<Permission?> UpdatePermissionAsync(Permission permission);

    /// <summary>
    /// Delete an Permission entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeletePermissionAsync(int id);
}