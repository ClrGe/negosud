using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

public class GetBottleService : IGetBottleService
{
    private readonly NegoSudDbContext _context;
    private readonly ILogger<BottleService> _logger;

    public GetBottleService(NegoSudDbContext context,
                                        ILogger<BottleService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Bottle?> GetBottleAsync(int id, bool includeRelations = true)
    {
        try
        {
            if (includeRelations)
            {
                return await _context.Bottles
                    .Include(b => b.Producer)
                    .Include(b => b.BottleStorageLocations)
                    .ThenInclude(bl => bl.StorageLocation)
                    .Include(b => b.BottleSuppliers)
                    .ThenInclude(bs => bs.Supplier)
                    .Include(b => b.BottleGrapes)
                    .ThenInclude(bg => bg.Grape)
                    .Include(b =>b.Vat)
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
}

