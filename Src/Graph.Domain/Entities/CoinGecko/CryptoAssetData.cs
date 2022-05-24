using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class CryptoAssetData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Abbreviation { get; set; } = string.Empty;

        [JsonPropertyName("market_data")]
        public MarketData? MarketData { get; set; }
    }
}
