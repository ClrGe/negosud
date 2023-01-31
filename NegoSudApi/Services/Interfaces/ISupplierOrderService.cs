using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ISupplierOrderService
{

    /// <summary>
    /// Get a SupplierOrder entity from the database by its id, , including or not subobjects and collections
    /// </summary>
    /// <param name="id">The SupplierOrder's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A SupplierOrder with the desired id, or null if it doesn't exist</returns>
    Task<SupplierOrder?> GetSupplierOrderAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of SupplierOrders from the database
    /// </summary>
    /// <returns>A collection of SupplierOrder</returns>
    Task<IEnumerable<SupplierOrder>?> GetSupplierOrdersAsync();

    /// <summary>
    /// Create a new SupplierOrder entity in the database
    /// </summary>
    /// <param name="supplierOrder">The entity's model</param>
    /// <returns>A SupplierOrder</returns>
    Task<SupplierOrder?> AddSupplierOrderAsync(SupplierOrder supplierOrder);

    /// <summary>
    /// Update a SupplierOrder entity in the database from a new model
    /// </summary>
    /// <param name="supplierOrder">The new entity's model</param>
    /// <returns>A SupplierOrder</returns>
    Task<SupplierOrder?> UpdateSupplierOrderAsync(SupplierOrder supplierOrder);

    /// <summary>
    /// Delete a SupplierOrder entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteSupplierOrderAsync(int id);
}