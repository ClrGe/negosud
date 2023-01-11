using Microsoft.EntityFrameworkCore;
using NegoSudApi.Models;

namespace NegoSudApi.Services

{
    public class ProducerService : IProducerService
    {

        private readonly NegoSudDbContext _context;

        public ProducerService(NegoSudDbContext context)
        {
            _context = context;
        }

        public async Task<Producer?> GetProducer(int id)

        {
            try
            {
                return await _context.Producers.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Producer>?> GetProducers()

        {
            try
            {
                return await _context.Producers.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Producer?> AddProducer(Producer producer)

        {
            try
            {
                await _context.Producers.AddAsync(producer);
                await _context.SaveChangesAsync();
                return await _context.Producers.FindAsync(producer.Id);
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

        public async Task<Producer?> UpdateProducer(Producer producer)

        {
            try
            {
                _context.Entry(producer).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return producer;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

        public async Task<bool?> DeleteProducer(Producer producer)

        {
            try
            {
                Producer? producerResult = await _context.Producers.FindAsync(producer.Id);

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
                return false;
            }
        }
    }
}