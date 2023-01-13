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

                currentBottle.Full_Name = bottle.Full_Name;
                currentBottle.Description = bottle.Description;
                currentBottle.Label = bottle.Label;
                currentBottle.Volume = bottle.Volume;
                currentBottle.Picture = bottle.Picture;
                currentBottle.Year_Produced = bottle.Year_Produced;
                currentBottle.Alcohol_Percentage = bottle.Alcohol_Percentage;
                currentBottle.Current_Price = bottle.Current_Price;


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
                            _context.Entry(existingBottleLocation).State = EntityState.Modified;
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
                        //currentBottle.BottleLocations.Remove(bottleLocationToDelete);
                        currentBottle.BottleLocations.Remove(bottleLocationToDelete);
                    }

                }


                if (bottle.BottleGrapes != null && currentBottle.BottleGrapes != null)
                {

                    ICollection<BottleGrape>? currentBottleGrapes = currentBottle.BottleGrapes.ToList();

                    foreach (BottleGrape bottleGrape in bottle.BottleGrapes)
                    {
                        //if the BottleGrape already exists
                        BottleGrape? existingBottleGrape = currentBottleGrapes.FirstOrDefault(bl => bl.Bottle_Id == bottleGrape.Bottle_Id && bl.Grape_Id == bottleGrape.Grape_Id);

                        if (existingBottleGrape != null)
                        {
                            //update the existing BottleGrape
                            existingBottleGrape.Grape_Percentage = bottleGrape.Grape_Percentage;
                            _context.Entry(existingBottleGrape).State = EntityState.Modified;
                            currentBottleGrapes.Remove(existingBottleGrape);
                        }
                        else
                        {
                            // otherwise, add the new BottleGrape to the current bottle
                            currentBottle.BottleGrapes.Add(bottleGrape);
                        }

                    }

                    foreach (BottleGrape bottleGrapeToDelete in currentBottleGrapes)
                    {
                        //currentBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                        currentBottle.BottleGrapes.Remove(bottleGrapeToDelete);
                    }

                }


                _context.Entry(currentBottle).State = EntityState.Modified;

                await _context.SaveChangesAsync();

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
