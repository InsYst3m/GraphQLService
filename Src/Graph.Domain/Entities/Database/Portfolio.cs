namespace Graph.Domain.Entities.Database
{
    public class Portfolio
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public decimal Capitalization { get; set; }

        public IList<CryptoTransaction> CryptoTransactions { get; set; } = new List<CryptoTransaction>();
    }
}
