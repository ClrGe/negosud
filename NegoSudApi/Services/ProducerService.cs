using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class ProducerService : IProducerService
{

    private readonly NegoSudDbContext _context;
    private readonly ILogger<ProducerService> _logger;

    public ProducerService(NegoSudDbContext context, ILogger<ProducerService> logger)
    {
        _context = context;
        _logger = logger;
    }

    //</inheritdoc> 
    public async Task<Producer?> GetProducerAsync(int id)
    {
        try
        {
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
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
            return await _context.Producers.FindAsync(producer.Id);
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

        return null;
    }
}