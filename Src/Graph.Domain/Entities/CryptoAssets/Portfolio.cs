using Graph.Domain.Entities.Common;

namespace Graph.Domain.Entities.CryptoAssets
{
    public class Portfolio
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public IList<CryptoTransaction> CryptoTransactions { get; set; } = new List<CryptoTransaction>();
    }
}
