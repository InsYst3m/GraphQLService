namespace Graph.Domain.Entities.Database
{
    public class CryptoAsset
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string CoinGeckoAbbreviation { get; set; } = string.Empty;

        public IList<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
