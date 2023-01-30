using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ISupplierService
{
    /// <summary>
    /// Get a Supplier entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The Country's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A Supplier with the desired id, or null if it doesn't exist</returns>
    Task<Supplier?> GetSupplierAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of Suppliers from the database
    /// </summary>
    /// <returns>A collection of Supplier</returns>
    Task<IEnumerable<Supplier>?> GetSuppliersAsync();

    /// <summary>
    /// Create a new Supplier entity in the database
    /// </summary>
    /// <param name="supplier">The entity's model</param>
    /// <returns>A Supplier</returns>
    Task<Supplier?> AddSupplierAsync(Supplier supplier);

    /// <summary>
    /// Update a Supplier entity in the database from a new model
    /// </summary>
    /// <param name="supplier">The new entity's model</param>
    /// <returns>A Supplier</returns>
    Task<Supplier?> UpdateSupplierAsync(Supplier supplier);

    /// <summary>
    /// Delete a Supplier entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteSupplierAsync(int id);
}