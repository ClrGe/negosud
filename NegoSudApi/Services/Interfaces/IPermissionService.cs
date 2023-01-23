using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IPermissionService
{

    /// <summary>
    /// Get a Permission entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Permission's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Permission with the desired id, or null if it doesn't exist</returns>
    Task<Permission?> GetPermissionAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Permissions from the database
    /// </summary>
    /// <returns>A collection of Permission</returns>
    Task<IEnumerable<Permission>?> GetPermissionsAsync();

    /// <summary>
    /// Create a new Permission entity in the database
    /// </summary>
    /// <param name="permission">The entity's model</param>
    /// <returns>A Permission</returns>
    Task<Permission?> AddPermissionAsync(Permission permission);

    /// <summary>
    /// Update a Permission entity in the database from a new model
    /// </summary>
    /// <param name="permission">The new entity's model</param>
    /// <returns>A Permission</returns>
    Task<Permission?> UpdatePermissionAsync(Permission permission);

    /// <summary>
    /// Delete a Permission entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeletePermissionAsync(int id);
}