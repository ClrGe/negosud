﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class AddressService : IAddressService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<AddressService> _logger;
    private readonly ICityService _cityService;

    public AddressService(NegoSudDbContext context, ILogger<AddressService> logger, ICityService cityService)
    {
        _context = context;
        _logger = logger;
        _cityService = cityService;
    }

    // <inheritdoc />
    public async Task<Address?> GetAddressAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Addresses
                    .Include(c => c.City)
                    .ThenInclude(c => c.Country)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            return await _context.Addresses.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // <inheritdoc />
    public async Task<IEnumerable<Address>?> GetAddressesAsync()
    {
        try
        {
            return await _context.Addresses.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // <inheritdoc />
    public async Task<Address?> AddAddressAsync(Address address)
    {
        if (address.CityId != null)
        {
            City? city = null;
            city = await _cityService.GetCityAsync((int)address.CityId, includeRelations: false);

            if (city != null)
            {
                address.City = city;
            }
        }

        // If we found a city in the database
        //// If we want to add a new city into the database from the AddAddress form
        //else if (address.City != null)
        //{
        //    address.City = await _cityService.AddCityAsync(address.City);
        //}

        // Create the region in the database
        Address newAddress = (await _context.Addresses.AddAsync(address)).Entity;

        await _context.SaveChangesAsync();

        return newAddress;
    }

    // <inheritdoc />
    public async Task<Address?> UpdateAddressAsync(Address address)
    {
        try
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return address;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    // <inheritdoc />
    public async Task<bool?> DeleteAddressAsync(int id)
    {
        try
        {
            var dbAddress = await _context.Addresses.FindAsync(id);

            if (dbAddress == null)
            {
                return false;
            }

            _context.Addresses.Remove(dbAddress);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return false;
    }
}