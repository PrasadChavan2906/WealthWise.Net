using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WealthWise.API.Models;

namespace WealthWise.API.Data
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly AppDbContext _context;

		public TransactionRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Transaction> GetTransactionByIdAsync(int id)
		{
			return await _context.Transactions.FindAsync(id);
		}

		public async Task AddTransactionAsync(Transaction transaction)
		{
			await _context.Transactions.AddAsync(transaction);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateTransactionAsync(Transaction transaction)
		{
			_context.Transactions.Update(transaction);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTransactionAsync(int id)
		{
			var transaction = await _context.Transactions.FindAsync(id);
			if (transaction != null)
			{
				_context.Transactions.Remove(transaction);
				await _context.SaveChangesAsync();
			}
		}
	}
}
