using System.Threading.Tasks;
using WealthWise.API.Models;

namespace WealthWise.API.Data
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByIdAsync(int id);
        Task AddWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(int id);
    }
}
