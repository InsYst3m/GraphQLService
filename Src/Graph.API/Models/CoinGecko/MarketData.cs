using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public CurrentPrice? CurrentPrice { get; set; }
    }
}
