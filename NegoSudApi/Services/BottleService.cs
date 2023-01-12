using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class BottleService : IBottleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<BottleService> _logger;
    private readonly IProducerService _producerService;
    private readonly ILocationService _locationService;
    private readonly IGrapeService _grapeService;

    public BottleService(NegoSudDbContext context, ILogger<BottleService> logger, IProducerService producerService, ILocationService locationService, IGrapeService grapeService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
        _locationService = locationService;
        _grapeService = grapeService;
    }     

    //</inheritdoc>  
    public async Task<Bottle?> GetBottleAsync(int id, bool includes = true)
    {
        try
        {
            if (includes)
            {
                return await _context.Bottles
                    .Include(b => b.Producer)
                    .Include(b => b.BottleLocations)
                    .ThenInclude(bl => bl.Location)
                    .Include(b => b.BottleGrapes)
                    .ThenInclude(bg => bg.Grape)
                    .FirstOrDefaultAsync(b => b.Id == id);
            }
            return await _context.Bottles.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
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
            await _context.Bottles.AddAsync(bottle);
            await _context.SaveChangesAsync();
            return await _context.Bottles.FindAsync(bottle.Id); // Auto ID from DB
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
            Bottle? currentBottle = await this.GetBottleAsync(bottle.Id);

            if (currentBottle != null)
            {


                if (bottle.Producer != null)
                {
                    Producer? producer = await _producerService.GetProducerAsync(bottle.Producer.Id, includes: false);
                    // If we found a producer in the database
                    if (producer != null)
                    {
                        currentBottle.Producer = producer;
                    }
                }



                if (bottle.BottleLocations != null && currentBottle.BottleLocations != null)
                {

                        ICollection<BottleLocation>? currentBottleLocations = currentBottle.BottleLocations.ToList();

                        foreach (BottleLocation bottleLocation in bottle.BottleLocations)
                        {
                            //if the BottleLocation already exists
                            BottleLocation? existingBottleLocation = currentBottleLocations.FirstOrDefault(bl => bl.Bottle_Id == bottleLocation.Bottle_Id && bl.Location_Id == bottleLocation.Location_Id);

                            if (existingBottleLocation != null)
                            {
                                //update the existing BottleLocation
                                existingBottleLocation.Quantity = bottleLocation.Quantity;
                                currentBottleLocations.Remove(existingBottleLocation);
                            }
                            else
                            {
                                // otherwise, add the new BottleLocation to the current bottle
                                currentBottle.BottleLocations.Add(bottleLocation);
                            }

                        }

                        foreach (BottleLocation bottleLocationToDelete in currentBottleLocations)
                        {
                            currentBottle.BottleLocations.Remove(bottleLocationToDelete);
                        }
                }





                //if (bottle.BottleGrapes != null)
                //{
                //    foreach (var bottleGrappe in bottle.BottleGrapes)
                //    {
                //        if (bottleGrappe.Grape?.Id != null)
                //        {
                //            Grape? grape = await _grapeService.GetGrapeAsync(bottleGrappe.Grape.Id, includes: false);
                //            if (grape != null)
                //            {
                //                bottleGrappe.Grape = grape;
                //                bottleGrappe.Bottle = bottle;

                //            }
                //        }
                //    }
                //}

                //_context.Entry(bottle).State = EntityState.Modified;
                //_context.Entry(currentBottle).State = EntityState.Modified;
                if (_context.ChangeTracker.HasChanges())
                {
                await _context.SaveChangesAsync();
                }

            return currentBottle;
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

        return null;
    }
}
