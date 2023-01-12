using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class BottleService : IBottleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<BottleService> _logger;
    private readonly IProducerService _producerService;

    public BottleService(NegoSudDbContext context, ILogger<BottleService> logger, IProducerService producerService)
    {
        _context = context;
        _logger = logger;
        _producerService = producerService;
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

            if (bottle.Producer?.Id != null)
            {
                Producer? producer = await _producerService.GetProducerAsync(bottle.Producer.Id, includes: false);
                // If we found a producer in the database
                if (producer != null)
                {
                    bottle.Producer = producer;
                }
            }

            _context.Entry(bottle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return bottle;
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
