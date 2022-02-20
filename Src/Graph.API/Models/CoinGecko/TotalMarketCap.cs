using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class TotalMarketCap
    {
        [JsonPropertyName("usd")]
        public decimal Usd { get; set; }
    }
}