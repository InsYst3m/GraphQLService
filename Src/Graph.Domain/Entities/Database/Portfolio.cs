namespace Graph.Domain.Entities.Database
{
    public class Portfolio
    {
        public Portfolio(User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            User = user;
        }

        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public decimal Capitalization => CryptoTransactions.Sum(x => x.TotalPrice);

        public long UserId { get; set; }
        public User User { get; set; }
        public IList<CryptoTransaction> CryptoTransactions { get; set; } = new List<CryptoTransaction>();
    }
}
