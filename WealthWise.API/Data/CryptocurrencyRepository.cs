using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WealthWise.API.Models;

namespace WealthWise.API.Data
{
    public class CryptocurrencyRepository : ICryptocurrencyRepository
    {
        private readonly AppDbContext _context;

        public CryptocurrencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cryptocurrency> GetCryptocurrencyByIdAsync(int id)
        {
            return await _context.Cryptocurrencies.FindAsync(id);
        }

        public async Task AddCryptocurrencyAsync(Cryptocurrency cryptocurrency)
        {
            await _context.Cryptocurrencies.AddAsync(cryptocurrency);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCryptocurrencyAsync(Cryptocurrency cryptocurrency)
        {
            _context.Cryptocurrencies.Update(cryptocurrency);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCryptocurrencyAsync(int id)
        {
            var cryptocurrency = await _context.Cryptocurrencies.FindAsync(id);
            if (cryptocurrency != null)
            {
                _context.Cryptocurrencies.Remove(cryptocurrency);
                await _context.SaveChangesAsync();
            }
        }
    }
}
