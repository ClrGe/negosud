﻿using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services
{
    public class CountryService
    {
        private readonly NegoSudContext _context;
        public CountryService(NegoSudContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>?> GetCountriesAsync()
        {
            try
            {
                return await _context.Countries.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Country?> GetCountryAsync(int id)
        {
            try
            {
                return await _context.Countries.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Country?> AddCountryAsync(Country country)
        {
            try
            {
                await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
                return await _context.Countries.FindAsync(country.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Country?> UpdateCountryAsync(Country country)
        {
            try
            {
                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return country;
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<bool?> DeleteCountryAsync(Country country)
        {
            try
            {
                var dbCountry = await _context.Countries.FindAsync(country.Id);

                if (dbCountry == null)
                {
                    return false;
                }

                _context.Countries.Remove(country);
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