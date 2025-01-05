namespace WealthWise.API.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int CryptocurrencyId { get; set; }
		public Cryptocurrency Cryptocurrency { get; set; }
		public decimal Amount { get; set; }
		public decimal Price { get; set; }
		public DateTime OrderDate { get; set; }
		
	}
}
