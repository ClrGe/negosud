﻿using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NegoSudApi.Models;
using Npgsql;

namespace NegoSudApi.Services
{
    public class GrapeService : IGrapeService
    {
        private readonly NegoSudContext _context;
        public GrapeService(NegoSudContext context) 
        {
            _context = context;
        }

        //</inheritdoc>
        public async Task<Grape?> GetGrapeAsync(int grapeId)
        {
            try
            {
                return await _context.Grapes.FindAsync(grapeId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>      
        public async Task<IEnumerable<Grape>?> GetGrapesAsync()
        {
            try
            {
                return await _context.Grapes.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>
        public async Task<Grape?> AddGrapeAsync(Grape model)
        {
            try
            {
                await _context.Grapes.AddAsync(model);
                await _context.SaveChangesAsync();
                return await _context.Grapes.FirstOrDefaultAsync(x => x.Id == model.Id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //</inheritdoc>
        public async Task<Grape?> UpdateGrapeAsync(Grape model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        //</inheritdoc>
        public async Task DeleteGrapeAsync(int grapeId)
        {
            try
            {
                Grape? grape = await _context.Grapes.FindAsync(grapeId);
                if(grape != null)
                {
                    _context.Grapes.Remove(grape);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        //</inheritdoc>
        public Task<IEnumerable<BottleGrape>?> GetBottleGrapesAsync(int grapeId) => throw new NotImplementedException();

        //</inheritdoc>
        public async Task<IEnumerable<Bottle>?> GetBottlesAsync(int grapeId) 
        {
            try
            {
                Grape? grape = await _context.Grapes.FindAsync(grapeId);
                if (grape != null)
                {
                    return await _context.Bottles.Include(b => b.Grapes).Where(b => b.Id == grapeId).ToListAsync();
                }
               
                return Enumerable.Empty<Bottle>();
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
