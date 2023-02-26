using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IVatService
{
    /// <summary>
    /// Get a VAT entity from the database by its id, including or not subobjects and collections
    /// </summary>
    /// <param name="id">The VAT's id</param>
    /// <returns>An VAT with the desired id, or null if it doesn't exist</returns>
    Task<VAT?> GetVatAsync(int id);

    /// <summary>
    /// Get an IEnumerable of VATes from the database
    /// </summary>
    /// <returns>A collection of VAT</returns>
    Task<IEnumerable<VAT>?> GetVatsAsync();

    /// <summary>
    /// Create a new VAT entity in the database
    /// </summary>
    /// <param name="vat">The entity's model</param>
    /// <returns>An VAT</returns>
    Task<VAT?> AddVatAsync(VAT vat);

    /// <summary>
    /// Update an VAT entity in the database from a new model
    /// </summary>
    /// <param name="vat">The new entity's model</param>
    /// <returns>An VAT</returns>
    Task<VAT?> UpdateVatAsync(VAT vat);

    /// <summary>
    /// Delete a VAT entity from the database
    /// </summary>
    /// <param name="id">The entity's id</param>
    /// <returns></returns>
    Task<bool?> DeleteVatAsync(int id);
}