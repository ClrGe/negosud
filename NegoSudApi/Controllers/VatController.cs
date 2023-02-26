using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VatController :ControllerBase
{
    private readonly IVatService _vatService;

    public VatController(IVatService vatService)
    {
        _vatService = vatService;
    }

    [Authorize(Policy = RolePermissions.CanGetVat)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVatAsync(int id)
    {
        VAT? dbVat = await _vatService.GetVatAsync(id);

        if (dbVat == null) return StatusCode(StatusCodes.Status404NotFound, $"No Vat found for id: {id}");

        return StatusCode(StatusCodes.Status200OK, dbVat);
    }

    [Authorize(Policy = RolePermissions.CanGetVat)]
    [HttpGet]
    public async Task<IActionResult> GetVatsAsync()
    {
        IEnumerable<VAT>? dbCountries = await _vatService.GetVatsAsync();

        if (dbCountries == null) return StatusCode(StatusCodes.Status404NotFound, "No Vats in database");

        return StatusCode(StatusCodes.Status200OK, dbCountries);
    }

    [Authorize(Policy = RolePermissions.CanAddVat)]
    [HttpPost("AddVat")]
    public async Task<ActionResult<VAT>> AddVatAsync(VAT vat)
    {
        VAT? dbVat = await _vatService.AddVatAsync(vat);

        if (dbVat == null) return StatusCode(StatusCodes.Status404NotFound, $"{vat.Value} could not be added.");

        return StatusCode(StatusCodes.Status201Created, dbVat);
    }

    [Authorize(Policy = RolePermissions.CanEditVat)]
    [HttpPost("UpdateVat")]
    public async Task<IActionResult> UpdateVatAsync(VAT Vat)
    {
        if (Vat == null) return BadRequest();
     
        VAT? dbVat = await _vatService.UpdateVatAsync(Vat);

        if (dbVat == null)
            return StatusCode(StatusCodes.Status404NotFound, $"No Vat found for id: {Vat.Id} - could not update.");

        return StatusCode(StatusCodes.Status200OK, dbVat);
    }

    [Authorize(Policy = RolePermissions.CanDeleteVat)]
    [HttpPost("DeleteVat")]
    public async Task<IActionResult> DeleteVatAsync([FromBody]int id)
    {
        bool? status = await _vatService.DeleteVatAsync(id);

        if (status == false)
            return StatusCode(StatusCodes.Status404NotFound, $"No Vat found for id: {id} - could not delete");

        return StatusCode(StatusCodes.Status200OK);
    }
}



