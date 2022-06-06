namespace Graph.Domain.Entities.Database
{
    public class CryptoTransaction
    {
        public CryptoTransaction(Portfolio portfolio, CryptoAsset cryptoAsset, User user)
        {
            ArgumentNullException.ThrowIfNull(portfolio, nameof(portfolio));
            ArgumentNullException.ThrowIfNull(cryptoAsset, nameof(cryptoAsset));
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            Portfolio = portfolio;
            CryptoAsset = cryptoAsset;
            User = user;
        }

        public Portfolio Portfolio { get; set; }
        public CryptoAsset CryptoAsset { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal TotalBuyPrice => Amount * BuyPrice;
        public decimal TotalPrice => Amount * CurrentPrice;
        public decimal Profit => TotalPrice - TotalBuyPrice;
        public decimal ProfitPercentage => (TotalPrice - TotalBuyPrice) / TotalBuyPrice * 100;
    }
}
