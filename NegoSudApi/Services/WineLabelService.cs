using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using NegoSudApi.Data;
using NegoSudApi.Models;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services
{
    public class WineLabelService : IWineLabelService
    {
        private readonly NegoSudDbContext _context;
        private readonly ILogger<WineLabelService> _logger;

        public async Task<WineLabel?> GetWineLabelAsync(int id, bool includes = true)
        {
            try
            {
                if (includes)
                {
                    return await _context.WineLabels
                    .Include(c => c.Bottles)
                    .FirstOrDefaultAsync(c => c.Id == id);
                }

                return await _context.WineLabels.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        public async Task<IEnumerable<WineLabel>?> GetWineLabelsAsync()
        {
            try
            {
                return await _context.WineLabels.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        public async Task<WineLabel?> AddWineLabelAsync(WineLabel wineLabel)
        {
            try
            {
                WineLabel newWineLabel = (await _context.WineLabels.AddAsync(wineLabel)).Entity;
                await _context.SaveChangesAsync();
                return newWineLabel;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        public async Task<WineLabel?> UpdateWineLabelAsync(WineLabel wineLabel)
        {
            try
            {
                _context.Entry(wineLabel).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return wineLabel;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
            }

            return null;
        }

        public async Task<bool?> DeleteWineLabelAsync(int id)
        {
            try
            {
                var dbWineLabel = await _context.WineLabels.FindAsync(id);

                if (dbWineLabel == null)
                {
                    return false;
                }

                _context.WineLabels.Remove(dbWineLabel);
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
}
