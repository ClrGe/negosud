using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;



[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    /// <summary>
    /// Method to return a Supplier matching query
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Policy = RolePermissions.CanGetSupplier)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierAsync(int id)
    {
        Supplier? dbSupplier = await _supplierService.GetSupplierAsync(id);

        if (dbSupplier == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No supplier found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbSupplier);
    }

    /// <summary>
    /// Method to return all existing Suppliers
    /// </summary>
    /// <returns></returns>
    [Authorize(Policy = RolePermissions.CanGetSupplier)]
    [HttpGet]
    public async Task<IActionResult> GetSuppliersAsync()
    {
        IEnumerable<Supplier>? dbSuppliers = await _supplierService.GetSuppliersAsync();

        if (dbSuppliers == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No suppliers in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbSuppliers);
    }


    /// <summary>
    /// Method to add a new Supplier to the database
    /// </summary>
    /// <param name="supplier"></param>
    /// <returns></returns>
    [Authorize(Policy = RolePermissions.CanAddSupplier)]
    [HttpPost("AddSupplier")]
    public async Task<ActionResult<Supplier>> AddSupplierAsync(Supplier supplier)
    {
        Supplier? dbSupplier = await _supplierService.AddSupplierAsync(supplier);

        if (dbSupplier == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"{supplier.Name} could not be added.");
        }

        return StatusCode(StatusCodes.Status201Created, dbSupplier);
    }


    /// <summary>
    /// update existing record matching query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="supplier"></param>
    /// <returns></returns>
    [Authorize(Policy = RolePermissions.CanEditSupplier)]
    [HttpPost("UpdateSupplier")]
    public async Task<IActionResult> UpdateSupplierAsync(Supplier supplier)
    {
        if (supplier == null)
        {
            return BadRequest();
        }

        Supplier? dbSupplier = await _supplierService.UpdateSupplierAsync(supplier);

        if (dbSupplier == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Supplier found for id: {supplier.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbSupplier);
    }


    /// <summary>
    /// Delete individual Supplier matching query
    /// </summary>
    /// <param name="id">The Supplier's id to delete</param>
    /// <returns>Status code</returns>
    [Authorize(Policy = RolePermissions.CanDeleteSupplier)]
    [HttpPost("DeleteSupplier")]
    public async Task<IActionResult> DeleteSupplierAsync(int id)
    {
        Supplier? dbSupplier = await _supplierService.GetSupplierAsync(id);

        if (dbSupplier == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Supplier found for id: {id} - could not be deleted");
        }

        await _supplierService.DeleteSupplierAsync(id);

        return StatusCode(StatusCodes.Status200OK, $"Supplier deleted with success");
    }

}


