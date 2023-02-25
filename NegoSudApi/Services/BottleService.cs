using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class BottleService : IBottleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<BottleService> _logger;
    private readonly IProducerService _producerService;
    private readonly IGrapeService _grapeService;
    private readonly IGetBottleService _getBottleService;
    private readonly IGetStorageLocationService _getStorageLocationService;
    private readonly IWineLabelService _wineLabelService;
    private readonly ISupplierService _supplierService;
    private readonly IVatService _vatService;

    public BottleService(NegoSudDbContext context,
        ILogger<BottleService> logger,
        IProducerService producerService,
        IGrapeService grapeService,
        IWineLabelService wineLabelService,
        ISupplierService supplierService, 
        IGetBottleService getBottleService,
        IGetStorageLocationService getStorageLocationService, IVatService vatService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
        _grapeService = grapeService;
        _getBottleService = getBottleService;
        _getStorageLocationService = getStorageLocationService;
        _vatService = vatService;
        _wineLabelService = wineLabelService;
        _supplierService = supplierService;
    }

    //</inheritdoc>  
    public async Task<Bottle?> GetBottleAsync(int id, bool includeRelations = true)
    {
        return await _getBottleService.GetBottleAsync(id, includeRelations);
    }

    //</inheritdoc>  
    public async Task<IEnumerable<Bottle>?> GetBottlesAsync()
    {
        try
        {
            return await _context.Bottles.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<Bottle?> AddBottleAsync(Bottle bottle)
    {
        try
        {
            if (bottle.BottleStorageLocations != null)
            {
                foreach (BottleStorageLocation bottleStorageLocation in bottle.BottleStorageLocations)
                {
                    if (bottleStorageLocation.StorageLocation?.Id != null)
                    {
                        StorageLocation? location =
                            await _getStorageLocationService.GetStorageLocationAsync(
                                bottleStorageLocation.StorageLocation.Id, includeRelations: false);
                        if (location != null)
                        {
                            bottleStorageLocation.StorageLocation = location;
                            bottleStorageLocation.Bottle = bottle;
                        }
                    }
                }
            }

            if (bottle.BottleGrapes != null)
            {
                foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                {
                    if (bottleGrape.Grape?.Id != null)
                    {
                        Grape? grape = await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id, includeRelations: false);
                        if (grape != null)
                        {
                            bottleGrape.Grape = grape;
                            bottleGrape.Bottle = bottle;
                        }
                    }
                }
            }

            if (bottle.WineLabelId != null)
            {
                WineLabel? wineLabel =
                    await _wineLabelService.GetWineLabelAsync((int) bottle.WineLabelId, includeRelations: false);
                if (wineLabel != null)
                {
                    bottle.WineLabel = wineLabel;
                }
            }

            if (bottle.ProducerId != null)
            {
                Producer? producer =
                    await _producerService.GetProducerAsync((int) bottle.ProducerId, includeRelations: false);
                if (producer != null)
                {
                    bottle.Producer = producer;
                }
            } 
            
            if (bottle.VatId != null)
            {
                VAT? dbVat =
                    await _vatService.GetVatAsync((int) bottle.VatId);
                if (dbVat != null)
                {
                    bottle.Vat = dbVat;
                }
            }

            Bottle newBottle = (await _context.Bottles.AddAsync(bottle)).Entity;

            if (bottle.BottleStorageLocations != null)
            {
                await _context.AddRangeAsync(bottle.BottleStorageLocations);
            }

            if (bottle.BottleGrapes != null)
            {
                await _context.AddRangeAsync(bottle.BottleGrapes);
            }

            await _context.SaveChangesAsync();

            return newBottle;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
    
    //</inheritdoc>  
    public async Task<ICollection<Bottle>?> MassAddBottleAsync(ICollection<Bottle>? bottles)
    {
        try
        {
            if (bottles != null)
            {
                foreach (Bottle bottle in bottles)
                {
                    if (bottle.BottleStorageLocations != null)
                    {
                        foreach (BottleStorageLocation bottleStorageLocation in bottle.BottleStorageLocations)
                        {
                            if (bottleStorageLocation.StorageLocation?.Id != null)
                            {
                                StorageLocation? location = await _getStorageLocationService.GetStorageLocationAsync(bottleStorageLocation.StorageLocation.Id, includeRelations: false);
                                if (location != null)
                                {
                                    bottleStorageLocation.StorageLocation = location;
                                    bottleStorageLocation.Bottle = bottle;
                                }
                            }
                            await _context.AddRangeAsync(bottle.BottleStorageLocations);
                        }
                    }
                    
                    if (bottle.BottleGrapes != null)
                    {
                        foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                        {
                            if (bottleGrape.Grape?.Id != null)
                            {
                                Grape? grape = await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id, includeRelations: false);
                                if (grape != null)
                                {
                                    bottleGrape.Grape = grape;
                                    bottleGrape.Bottle = bottle;
                                }
                            }
                            await _context.AddRangeAsync(bottle.BottleGrapes);
                        }
                    }

                    if (bottle.WineLabel?.Id != null)
                    {
                        WineLabel? wineLabel =
                            await _wineLabelService.GetWineLabelAsync(bottle.WineLabel.Id, includeRelations: false);
                        if (wineLabel != null)
                        {
                            bottle.WineLabel = wineLabel;
                        }
                    }

                    if (bottle.Producer?.Id != null)
                    {
                        Producer? producer =
                            await _producerService.GetProducerAsync(bottle.Producer.Id, includeRelations: false);
                        if (producer != null)
                        {
                            bottle.Producer = producer;
                        }
                    } 
            
                    if (bottle.Vat?.Id != null)
                    {
                        VAT? dbVat =
                            await _vatService.GetVatAsync(bottle.Vat.Id);
                        if (dbVat != null)
                        {
                            bottle.Vat = dbVat;
                        }
                    }
                }
                await _context.BulkInsertAsync(bottles);
                return bottles;

            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<Bottle?> UpdateBottleAsync(Bottle bottle)
    {
        try
        {
            // get the current bottle from db
            Bottle? dbBottle = await this.GetBottleAsync(bottle.Id);

            if (dbBottle != null)
            {
                dbBottle.FullName = bottle.FullName;
                dbBottle.Description = bottle.Description;
                dbBottle.WineLabel = bottle.WineLabel;
                dbBottle.Volume = bottle.Volume;
                dbBottle.Picture = bottle.Picture;
                dbBottle.YearProduced = bottle.YearProduced;
                dbBottle.AlcoholPercentage = bottle.AlcoholPercentage;
                dbBottle.SupplierPrice = bottle.SupplierPrice;
                dbBottle.CustomerPrice = bottle.CustomerPrice;


                if (bottle.ProducerId != null)
                {
                    Producer? producer =
                        await _producerService.GetProducerAsync((int) bottle.ProducerId, includeRelations: false);
                    // If we found a producer in the database
                    if (producer != null)
                    {
                        dbBottle.Producer = producer;
                    }
                }

                if (bottle.VatId != null)
                {
                    dbBottle.Vat = await _vatService.GetVatAsync((int) bottle.VatId) ?? dbBottle.Vat;

                }
                
                if (bottle.BottleStorageLocations != null && dbBottle.BottleStorageLocations != null)
                {
                    ICollection<BottleStorageLocation> dbBottleStorageLocations =
                        dbBottle.BottleStorageLocations.ToList();

                    foreach (BottleStorageLocation bottleStorageLocation in bottle.BottleStorageLocations)
                    {
                        //if the BottleStorageLocation already exists
                        BottleStorageLocation? existingBottleStorageLocation =
                            dbBottleStorageLocations.FirstOrDefault(bl =>
                                bl.BottleId == bottleStorageLocation.BottleId &&
                                bl.StorageLocationId == bottleStorageLocation.StorageLocationId);

                        if (existingBottleStorageLocation != null)
                        {
                            //update the existing BottleStorageLocation
                            existingBottleStorageLocation.Quantity = bottleStorageLocation.Quantity;
                            _context.Entry(existingBottleStorageLocation).State = EntityState.Modified;
                            dbBottleStorageLocations.Remove(existingBottleStorageLocation);
                        }
                        else
                        {
                            if (bottleStorageLocation.StorageLocation?.Id != null)
                            {
                                StorageLocation? location =
                                    await _getStorageLocationService.GetStorageLocationAsync(
                                        bottleStorageLocation.StorageLocation.Id, includeRelations: false);
                                if (location != null)
                                {
                                    bottleStorageLocation.StorageLocation = location;
                                    bottleStorageLocation.Bottle = bottle;
                                }
                            }

                            // otherwise, add the new BottleStorageLocation to the current bottle
                            dbBottle.BottleStorageLocations.Add(bottleStorageLocation);
                        }
                    }

                    foreach (BottleStorageLocation bottleStorageLocationToDelete in dbBottleStorageLocations)
                    {
                        dbBottle.BottleStorageLocations.Remove(bottleStorageLocationToDelete);
                    }
                }

                if (bottle.BottleSuppliers != null && dbBottle.BottleSuppliers != null)
                {
                    ICollection<BottleSupplier> dbBottleSuppliers = dbBottle.BottleSuppliers.ToList();

                    foreach (BottleSupplier bottleSupplier in bottle.BottleSuppliers)
                    {
                        //if the BottleSupplier already exists
                        BottleSupplier? existingBottleSupplier = dbBottleSuppliers.FirstOrDefault(bs =>
                            bs.BottleId == bottleSupplier.BottleId && bs.SupplierId == bottleSupplier.SupplierId);

                        if (existingBottleSupplier != null)
                        {
                            //update the existing BottleStorageLocation
                            existingBottleSupplier.Supplier = bottleSupplier.Supplier;
                            _context.Entry(existingBottleSupplier).State = EntityState.Modified;
                            dbBottleSuppliers.Remove(existingBottleSupplier);
                        }
                        else
                        {
                            if (bottleSupplier.Supplier?.Id != null)
                            {
                                Supplier? supplier = await _supplierService.GetSupplierAsync(bottleSupplier.Supplier.Id,
                                    includeRelations: false);
                                if (supplier != null)
                                {
                                    bottleSupplier.Supplier = supplier;
                                    bottleSupplier.Bottle = bottle;
                                }
                            }

                            // otherwise, add the new BottleStorageLocation to the current bottle
                            dbBottle.BottleSuppliers.Add(bottleSupplier);
                        }
                    }

                    foreach (BottleSupplier bottleSupplierToDelete in dbBottleSuppliers)
                    {
                        dbBottle.BottleSuppliers.Remove(bottleSupplierToDelete);
                    }
                }

                if (bottle.BottleGrapes != null && dbBottle.BottleGrapes != null)
                {
                    ICollection<BottleGrape> dbBottleGrapes = dbBottle.BottleGrapes.ToList();

                    foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                    {
                        //if the BottleGrape already exists
                        BottleGrape? existingBottleGrape = dbBottleGrapes.FirstOrDefault(bl =>
                            bl.BottleId == bottleGrape.BottleId && bl.GrapeId == bottleGrape.GrapeId);

                        if (existingBottleGrape != null)
                        {
                            //update the existing BottleGrape
                            existingBottleGrape.GrapePercentage = bottleGrape.GrapePercentage;
                            _context.Entry(existingBottleGrape).State = EntityState.Modified;
                            dbBottleGrapes.Remove(existingBottleGrape);
                        }
                        else
                        {
                            if (bottleGrape.Grape?.Id != null)
                            {
                                Grape? grape =
                                    await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id, includeRelations: false);
                                if (grape != null)
                                {
                                    bottleGrape.Grape = grape;
                                    bottleGrape.Bottle = bottle;
                                }
                            }

                            // otherwise, add the new BottleGrape to the current bottle
                            dbBottle.BottleGrapes.Add(bottleGrape);
                        }
                    }

                    foreach (BottleGrape bottleGrapeToDelete in dbBottleGrapes)
                    {
                        //currentBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                        dbBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                    }
                }


                _context.Entry(dbBottle).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return dbBottle;
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc>  
    public async Task<ICollection<Bottle>?> MassUpdateBottleAsync(ICollection<Bottle>? bottles)
    {
        try
        {
            if (bottles != null)
            {
                // same logic as individual update wrapped in a loop
                foreach (Bottle bottle in bottles)
                {
                    Bottle? dbBottle = await this.GetBottleAsync(bottle.Id);

                    if (dbBottle != null)
                    {
                        dbBottle.FullName = bottle.FullName;
                        dbBottle.Description = bottle.Description;
                        dbBottle.WineLabel = bottle.WineLabel;
                        dbBottle.Volume = bottle.Volume;
                        dbBottle.Picture = bottle.Picture;
                        dbBottle.YearProduced = bottle.YearProduced;
                        dbBottle.AlcoholPercentage = bottle.AlcoholPercentage;
                        dbBottle.SupplierPrice = bottle.SupplierPrice;
                        dbBottle.CustomerPrice = bottle.CustomerPrice;


                        if (bottle.Producer != null)
                        {
                            Producer? producer =
                                await _producerService.GetProducerAsync(bottle.Producer.Id, includeRelations: false);
                            if (producer != null)
                            {
                                dbBottle.Producer = producer;
                            }
                        }
                        if (bottle.Vat != null)
                        {
                            dbBottle.Vat = await _vatService.GetVatAsync(bottle.Vat.Id) ?? dbBottle.Vat;
                        }
                        if (bottle.BottleStorageLocations != null && dbBottle.BottleStorageLocations != null)
                        {
                            ICollection<BottleStorageLocation> dbBottleStorageLocations =
                                dbBottle.BottleStorageLocations.ToList();
                            foreach (BottleStorageLocation bottleStorageLocation in bottle.BottleStorageLocations)
                            {
                                BottleStorageLocation? existingBottleStorageLocation =
                                    dbBottleStorageLocations.FirstOrDefault(bl =>
                                        bl.BottleId == bottleStorageLocation.BottleId &&
                                        bl.StorageLocationId == bottleStorageLocation.StorageLocationId);
                                if (existingBottleStorageLocation != null)
                                {
                                    existingBottleStorageLocation.Quantity = bottleStorageLocation.Quantity;
                                    _context.Entry(existingBottleStorageLocation).State = EntityState.Modified;
                                    dbBottleStorageLocations.Remove(existingBottleStorageLocation);
                                }
                                else
                                {
                                    if (bottleStorageLocation.StorageLocation?.Id != null)
                                    {
                                        StorageLocation? location =
                                            await _getStorageLocationService.GetStorageLocationAsync(
                                                bottleStorageLocation.StorageLocation.Id, includeRelations: false);
                                        if (location != null)
                                        {
                                            bottleStorageLocation.StorageLocation = location;
                                            bottleStorageLocation.Bottle = bottle;
                                        }
                                    }
                                    dbBottle.BottleStorageLocations.Add(bottleStorageLocation);
                                }
                            }
                            foreach (BottleStorageLocation bottleStorageLocationToDelete in dbBottleStorageLocations)
                            {
                                dbBottle.BottleStorageLocations.Remove(bottleStorageLocationToDelete);
                            }
                        }
                        if (bottle.BottleSuppliers != null && dbBottle.BottleSuppliers != null)
                        {
                            ICollection<BottleSupplier> dbBottleSuppliers = dbBottle.BottleSuppliers.ToList();

                            foreach (BottleSupplier bottleSupplier in bottle.BottleSuppliers)
                            {
                                BottleSupplier? existingBottleSupplier = dbBottleSuppliers.FirstOrDefault(bs =>
                                    bs.BottleId == bottleSupplier.BottleId &&
                                    bs.SupplierId == bottleSupplier.SupplierId);
                                if (existingBottleSupplier != null)
                                {
                                    existingBottleSupplier.Supplier = bottleSupplier.Supplier;
                                    _context.Entry(existingBottleSupplier).State = EntityState.Modified;
                                    dbBottleSuppliers.Remove(existingBottleSupplier);
                                }
                                else
                                {
                                    if (bottleSupplier.Supplier?.Id != null)
                                    {
                                        Supplier? supplier = await _supplierService.GetSupplierAsync(
                                            bottleSupplier.Supplier.Id,
                                            includeRelations: false);
                                        if (supplier != null)
                                        {
                                            bottleSupplier.Supplier = supplier;
                                            bottleSupplier.Bottle = bottle;
                                        }
                                    }
                                    dbBottle.BottleSuppliers.Add(bottleSupplier);
                                }
                            }
                            foreach (BottleSupplier bottleSupplierToDelete in dbBottleSuppliers)
                            {
                                dbBottle.BottleSuppliers.Remove(bottleSupplierToDelete);
                            }
                        }
                        if (bottle.BottleGrapes != null && dbBottle.BottleGrapes != null)
                        {
                            ICollection<BottleGrape> dbBottleGrapes = dbBottle.BottleGrapes.ToList();
                            foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                            {
                                BottleGrape? existingBottleGrape = dbBottleGrapes.FirstOrDefault(bl =>
                                    bl.BottleId == bottleGrape.BottleId && bl.GrapeId == bottleGrape.GrapeId);
                                if (existingBottleGrape != null)
                                {
                                    existingBottleGrape.GrapePercentage = bottleGrape.GrapePercentage;
                                    _context.Entry(existingBottleGrape).State = EntityState.Modified;
                                    dbBottleGrapes.Remove(existingBottleGrape);
                                }
                                else
                                {
                                    if (bottleGrape.Grape?.Id != null)
                                    {
                                        Grape? grape =
                                            await _grapeService.GetGrapeAsync(bottleGrape.Grape.Id,
                                                includeRelations: false);
                                        if (grape != null)
                                        {
                                            bottleGrape.Grape = grape;
                                            bottleGrape.Bottle = bottle;
                                        }
                                    }
                                    dbBottle.BottleGrapes.Add(bottleGrape);
                                }
                            }

                            foreach (BottleGrape bottleGrapeToDelete in dbBottleGrapes)
                            {
                                dbBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                            }
                        }
                        await _context.BulkUpdateAsync(bottles);
                        return bottles;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    
    //</inheritdoc>  
    public async Task<bool?> DeleteBottleAsync(int id)
    {
        try
        {
            var dbBottle = await _context.Bottles.FindAsync(id);

            if (dbBottle == null)
            {
                return false;
            }

            _context.Bottles.Remove(dbBottle);
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