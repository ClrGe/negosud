﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public class BottleService : IBottleService
    {
        private readonly NegoSudContext _context;
        public BottleService(NegoSudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bottle>?> GetBottlesAsync()
        {
            try
            {
                return await _context.Bottles.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Bottle?> GetBottleAsync(int id)
        {
            try
            {
                return await _context.Bottles.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Bottle?> AddBottleAsync(Bottle Bottle)
        {
            try
            {
                await _context.Bottles.AddAsync(Bottle);
                await _context.SaveChangesAsync();
                return await _context.Bottles.FindAsync(Bottle.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Bottle?> UpdateBottleAsync(Bottle Bottle)
        {
            try
            {
                _context.Entry(Bottle).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Bottle;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool?> DeleteBottleAsync(Bottle Bottle)
        {
            try
            {
                var dbBottle = await _context.Bottles.FindAsync(Bottle.Id);

                if (dbBottle == null)
                {
                    return (false, "Bottle could not be found");
                }

                _context.Bottles.Remove(Bottle);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}