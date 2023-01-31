using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface ICustomerOrderService
{

    /// <summary>
    /// Get a CustomerOrder entity from the database by its id, , including or not subobjects and collections
    /// </summary>
    /// <param name="id">The CustomerOrder's id</param>
    /// <param name="includeRelations">Indicates whether or not subobjects and collections should be loaded (true if not specified)</param>
    /// <returns>A CustomerOrder with the desired id, or null if it doesn't exist</returns>
    Task<CustomerOrder?> GetCustomerOrderAsync(int id, bool includeRelations = true);

    /// <summary>
    /// Get an IEnumerable of CustomerOrders from the database
    /// </summary>
    /// <returns>A collection of CustomerOrder</returns>
    Task<IEnumerable<CustomerOrder>?> GetCustomerOrdersAsync();

    /// <summary>
    /// Create a new CustomerOrder entity in the database
    /// </summary>
    /// <param name="customerOrder">The entity's model</param>
    /// <returns>A CustomerOrder</returns>
    Task<CustomerOrder?> AddCustomerOrderAsync(CustomerOrder customerOrder);

    /// <summary>
    /// Update a CustomerOrder entity in the database from a new model
    /// </summary>
    /// <param name="customerOrder">The new entity's model</param>
    /// <returns>A CustomerOrder</returns>
    Task<CustomerOrder?> UpdateCustomerOrderAsync(CustomerOrder customerOrder);

    /// <summary>
    /// Delete a CustomerOrder entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteCustomerOrderAsync(int id);
}