using System.ComponentModel.DataAnnotations.Schema;

namespace Graph.DataAccess.Entities
{
    public class CryptoAsset
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string CoinGeckoAbbreviation { get; set; } = string.Empty;
    }
}
