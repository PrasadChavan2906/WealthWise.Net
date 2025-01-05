using System.Threading.Tasks;
using WealthWise.API.Models;

namespace WealthWise.API.Data
{
    public interface ICryptocurrencyRepository
    {
        Task<Cryptocurrency> GetCryptocurrencyByIdAsync(int id);
        Task AddCryptocurrencyAsync(Cryptocurrency cryptocurrency);
        Task UpdateCryptocurrencyAsync(Cryptocurrency cryptocurrency);
        Task DeleteCryptocurrencyAsync(int id);
    }
}
