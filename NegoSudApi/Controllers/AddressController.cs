using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressAsync(int id)
    {
        Address? dbAddress = await _addressService.GetAddressAsync(id);

        if (dbAddress == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No address found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, dbAddress);
    }

    [HttpGet]
    public async Task<IActionResult> GetAddressesAsync()
    {
        IEnumerable<Address>? dbAddresses = await _addressService.GetAddressesAsync();

        if (dbAddresses == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No addresses in database");
        }

        return StatusCode(StatusCodes.Status200OK, dbAddresses);
    }

    [HttpPost("AddAddress")]
    public async Task<ActionResult<Address>> AddAddressAsync(Address address)
    {
        Address? dbAddress = await _addressService.AddAddressAsync(address);

        if (dbAddress == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No match - could not add content.");
        }

        return StatusCode(StatusCodes.Status201Created, dbAddress);
    }

    [HttpPost("UpdateAddress")]
    public async Task<IActionResult> UpdateAddressAsync(Address address)
    {
        if (address == null)
        {
            return BadRequest();
        }

        Address? dbAddress = await _addressService.UpdateAddressAsync(address);

        if (dbAddress == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No address found for id: {address.Id} - could not update.");
        }

        return StatusCode(StatusCodes.Status200OK, dbAddress);
    }

    [HttpPost("DeleteAddress")]
    public async Task<IActionResult> DeleteAddressAsync(int id)
    {
        bool? status = await _addressService.DeleteAddressAsync(id);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status404NotFound, $"No address found for id: {id} - could not delete");
        }

        return StatusCode(StatusCodes.Status200OK);
    }
}

