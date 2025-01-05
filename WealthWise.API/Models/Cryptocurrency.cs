namespace WealthWise.API.Models
{
    public class Cryptocurrency
    {
        public int CryptocurrencyId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        
    }
}
