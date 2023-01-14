using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IStorageLocationService
{
    /// <summary>
    /// Get a StorageLocation entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The entity id</param>
    /// <param name="includes">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A StorageLocation object with the desired id, or null if it doesn't exist</returns>
    public Task<StorageLocation?> GetStorageLocationAsync(int id, bool includes = true);

    /// <summary>
    /// Get an IEnumerable of StorageLocation entities from the database
    /// </summary>
    /// <returns>A collection of StorageLocation object</returns>
    public Task<IEnumerable<StorageLocation>?> GetStorageLocationsAsync();

    /// <summary>
    /// Create a new StorageLocation entity in the database
    /// </summary>
    /// <param name="storageLocation">The model of the entity</param>
    /// <returns>A StorageLocation object</returns>
    public Task<StorageLocation?> AddStorageLocationAsync(StorageLocation storageLocation);

    /// <summary>
    /// Update a StorageLocation entity in the database
    /// </summary>
    /// <param name="storageLocation">The new entity's model</param>
    /// <returns>A StorageLocation object</returns>
    public Task<StorageLocation?> UpdateStorageLocationAsync(StorageLocation storageLocation);

    /// <summary>
    /// Delete a StorageLocation entity from the database
    /// </summary>
    /// <param name="id">The entity id</param>
    /// <returns></returns>
    public Task DeleteStorageLocationAsync(int id);
}