using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class ProducerService : IProducerService
{

    private readonly NegoSudDbContext _context;
    private readonly ILogger<ProducerService> _logger;
    private readonly IRegionService _regionService;

    public ProducerService(NegoSudDbContext context, ILogger<ProducerService> logger, IRegionService regionService)
    {
        _context = context;
        _logger = logger;
        _regionService = regionService;
    }

    //</inheritdoc> 
    public async Task<Producer?> GetProducerAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Producers
                    .Include(p => p.Region)
                    .Include(p => p.Bottles)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            return await _context.Producers.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<IEnumerable<Producer>?> GetProducersAsync()
    {
        try
        {
            return await _context.Producers.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Producer?> AddProducerAsync(Producer producer)
    {
        try
        {
            Region? region = null;
            if (producer.Region?.Id != null)
            {
                region = await _regionService.GetRegionAsync(producer.Region.Id, includeRelations: false);
            }
            
            // If we found a region in the database
            if (region != null)
            {
                producer.Region = region;
            }
            // If we want to add a new region into the database from the AddProducerForm
            else if (producer.Region!= null)
            {
                producer.Region = await _regionService.AddRegionAsync(producer.Region);
            }

            // Create the producer in the database
            Producer newProducer = (await _context.Producers.AddAsync(producer)).Entity;

            await _context.SaveChangesAsync();

            return newProducer;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<Producer?> UpdateProducerAsync(Producer producer)
    {
        try
        {
            if (producer.Region?.Id != null)
            {
                Region? region = await _regionService.GetRegionAsync(producer.Region.Id, includeRelations: false);
                // If we found a region in the database
                if (region != null)
                {
                    producer.Region = region;
                }
            }

            _context.Entry(producer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return producer;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }

    //</inheritdoc> 
    public async Task<bool?> DeleteProducerAsync(int id)
    {
        try
        {
            Producer? producerResult = await _context.Producers.FindAsync(id);

            if (producerResult == null)
            {
                return false;
            }

            _context.Producers.Remove(producerResult);
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