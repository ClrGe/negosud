using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IAddressService
{
    /// <summary>
    /// Get an Address entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Address's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>An Address with the desired id, or null if it doesn't exist</returns>
    Task<Address?> GetAddressAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Addresses from the database
    /// </summary>
    /// <returns>A collection of Address</returns>
    Task<IEnumerable<Address>?> GetAddressesAsync();

    /// <summary>
    /// Create a new Address entity in the database
    /// </summary>
    /// <param name="address">The entity's model</param>
    /// <returns>An Address</returns>
    Task<Address?> AddAddressAsync(Address address);

    /// <summary>
    /// Update an Address entity in the database from a new model
    /// </summary>
    /// <param name="address">The new entity's model</param>
    /// <returns>An Address</returns>
    Task<Address?> UpdateAddressAsync(Address address);

    /// <summary>
    /// Delete an Address entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteAddressAsync(int id);
}