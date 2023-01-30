using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Get a User entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The User's id</param>
    /// <returns>An User with the desired id, or null if it doesn't exist</returns>
    Task<User?> GetUserAsync(int id);

    /// <summary>
    /// Get an IEnumerable of Useres from the database
    /// </summary>
    /// <returns>A collection of User</returns>
    Task<IEnumerable<User>?> GetUsersAsync();

    /// <summary>
    /// Create a new User entity in the database
    /// </summary>
    /// <param name="user">The entity's model</param>
    /// <returns>An User</returns>
    Task<User?> AddUserAsync(User user);

    /// <summary>
    /// Update an User entity in the database from a new model
    /// </summary>
    /// <param name="user">The new entity's model</param>
    /// <returns>An User</returns>
    Task<User?> UpdateUserAsync(User user);

    /// <summary>
    /// Delete an User entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteUserAsync(int id);
}