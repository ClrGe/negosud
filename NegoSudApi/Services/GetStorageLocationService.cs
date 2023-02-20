using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class GetStorageLocationService : IGetStorageLocationService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<StorageLocationService> _logger;

    public GetStorageLocationService(NegoSudDbContext context,
                                        ILogger<StorageLocationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<StorageLocation?> GetStorageLocationAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.StorageLocations
                    .Include(l => l.BottleStorageLocations)
                    .ThenInclude(bl => bl.Bottle)
                    .FirstOrDefaultAsync(l => l.Id == id);
            }
            return await _context.StorageLocations.FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Information, ex.ToString());
        }

        return null;
    }
}

