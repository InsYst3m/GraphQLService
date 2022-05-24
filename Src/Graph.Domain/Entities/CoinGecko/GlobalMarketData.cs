using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class GlobalMarketData
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; } = null!;
    }

    public class Data
    {
        [JsonPropertyName("active_cryptocurrencies")]
        public long ActiveCryptoCurrencies { get; set; }

        [JsonPropertyName("total_market_cap")]
        public TotalMarketCap TotalMarketCap { get; set; } = null!;
    }
}
