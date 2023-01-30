using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Get a User entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Country's id</param>
    /// <returns>The user if exists</returns>
    Task<User?> GetUserAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Users from the database
    /// </summary>
    /// <returns>The list of all users registered</returns>
    Task<IEnumerable<User>?> GetUsersAsync();

    /// <summary>
    /// Create a new User entity in the database
    /// </summary>
    /// <param name="user">The entity's model</param>
    /// <returns>The user added</returns>
    Task<User?> AddUserAsync(User user);

    /// <summary>
    /// Update a User entity in the database from a new model
    /// </summary>
    /// <param name="user">The new entity's model</param>
    /// <returns></returns>
    Task<User?> UpdateUserAsync(User user);

    /// <summary>
    /// Delete a User entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteUserAsync(int id);
}