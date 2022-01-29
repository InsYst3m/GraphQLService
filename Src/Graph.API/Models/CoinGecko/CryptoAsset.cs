using Graph.API.Models.CoinGecko;
using System.Text.Json.Serialization;

namespace Graph.API.Models
{
    public class CryptoAsset
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Abbreviation { get; set; } = string.Empty;

        [JsonPropertyName("market_data")]
        public MarketData? MarketData { get; set; }
    }
}
