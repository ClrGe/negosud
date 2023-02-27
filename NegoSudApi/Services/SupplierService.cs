using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;
using System.Net;

namespace NegoSudApi.Services;

public class SupplierService : ISupplierService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<SupplierService> _logger;
    private readonly IAddressService _addressService;
    private readonly ICityService _cityService;
    private readonly IGetBottleService _getBottleService;

    public SupplierService(NegoSudDbContext context, ILogger<SupplierService> logger, IAddressService addressService, ICityService cityService, IGetBottleService getBottleService)
    {
        _context = context;
        _logger = logger;
        _addressService = addressService;
        _cityService = cityService;
        _getBottleService = getBottleService;
    }

    //</inheritdoc> 
    public async Task<Supplier?> GetSupplierAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Suppliers
                    .Include(p => p.BottleSuppliers)
                    .ThenInclude(bs => bs.Bottle)
                    .Include(s => s.Address)
                    .ThenInclude(a => a.City)
                    .ThenInclude(c => c.Country)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }

            return await _context.Suppliers.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }


    public async Task<IEnumerable<Supplier>?> GetSuppliersAsync()
    {
        try
        {
            return await _context.Suppliers.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Supplier?> AddSupplierAsync(Supplier supplier)
    {
        try
        {

            if (supplier.Address != null)
            {

                if (supplier.Address.CityId != null)
                {
                    City? city = null;
                    city = await _cityService.GetCityAsync((int)supplier.Address.CityId, includeRelations: false);

                    if (city != null)
                    {
                        supplier.Address.City = city;
                    }
                }

            }

            Supplier newSupplier = (await _context.Suppliers.AddAsync(supplier)).Entity;

            await _context.SaveChangesAsync();

            return newSupplier;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Supplier?> UpdateSupplierAsync(Supplier supplier)
    {
        try
        {
            Supplier? dbSupplier = await this.GetSupplierAsync(supplier.Id);

            if (dbSupplier != null)
            {
                dbSupplier.Details = supplier.Details;
                dbSupplier.Name = supplier.Name;
                dbSupplier.Email = supplier.Email;

                if (supplier.Address != null)
                {
                    Address? dbAddress = await _addressService.GetAddressAsync(supplier.Address.Id, false);
                    if (dbAddress != null)
                    {
                        if (supplier.Address.CityId != null)
                        {
                            City? city = null;
                            city = await _cityService.GetCityAsync((int)supplier.Address.CityId, includeRelations: false);

                            if (city != null)
                            {
                                supplier.Address.City = city;
                            }
                        }

                        dbAddress.AddressLine1 = supplier.Address.AddressLine1;
                        dbAddress.AddressLine2 = supplier.Address.AddressLine2;
                        dbAddress.City = supplier.Address.City;

                        dbSupplier.Address = dbAddress;
                        
                    }
                }




                if (supplier.BottleSuppliers != null && dbSupplier.BottleSuppliers != null)
                {
                    ICollection<BottleSupplier> dbBottleSuppliers = dbSupplier.BottleSuppliers.ToList();

                    foreach (BottleSupplier bottleSupplier in supplier.BottleSuppliers)
                    {
                        //if the BottleSupplier already exists
                        BottleSupplier? existingSupplier = dbBottleSuppliers.FirstOrDefault(bs =>
                            bs.BottleId == bottleSupplier.BottleId && bs.SupplierId == bottleSupplier.Supplier.Id);

                        if (existingSupplier != null)
                        {
                            //update the existing BottleStorageLocation
                            existingSupplier.Supplier = bottleSupplier.Supplier;
                            _context.Entry(existingSupplier).State = EntityState.Modified;
                            dbBottleSuppliers.Remove(existingSupplier);
                        }
                        else
                        {
                            Bottle? bottle = await _getBottleService.GetBottleAsync(bottleSupplier.SupplierId,
                                includeRelations: false);
                            if (bottle != null)
                            {
                                bottleSupplier.Supplier = supplier;
                                bottleSupplier.Bottle = bottle;
                            }


                            // otherwise, add the new BottleStorageLocation to the current bottle
                            dbSupplier.BottleSuppliers.Add(bottleSupplier);
                        }
                    }

                    foreach (BottleSupplier bottleSupplierToDelete in dbBottleSuppliers)
                    {
                        dbSupplier.BottleSuppliers.Remove(bottleSupplierToDelete);
                    }
                }

                _context.Entry(dbSupplier).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return supplier;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<bool?> DeleteSupplierAsync(int id)
    {
        try
        {
            Supplier? supplierResult = await _context.Suppliers.FindAsync(id);

            if (supplierResult == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplierResult);
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