﻿using Microsoft.AspNetCore.Mvc;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                return StatusCode(StatusCodes.Status204NoContent, $"No address found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, dbAddress);
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressesAsync()
        {
            IEnumerable<Address>? dbAddresses = await _addressService.GetAddressesAsync();

            if (dbAddresses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No addresses in database");
            }

            return StatusCode(StatusCodes.Status200OK, dbAddresses);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> AddAddressAsync(Address address)
        {
            Address? dbAddress = await _addressService.AddAddressAsync(address);

            if (dbAddress == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No match - could not add content.");
            }

            return StatusCode(StatusCodes.Status201Created, dbAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddressAsync(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            Address? dbAddress = await _addressService.UpdateAddressAsync(address);

            if (dbAddress == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No address found for id: {id} - could not update.");
            }

            return StatusCode(StatusCodes.Status200OK, dbAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            bool? status = await _addressService.DeleteAddressAsync(id);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No address found for id: {id} - could not delete");
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}