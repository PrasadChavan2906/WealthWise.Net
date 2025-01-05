namespace WealthWise.API.Models
{
	public class Wallet
	{
		public int WalletId { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public decimal Balance { get; set; }
		
	}
}
