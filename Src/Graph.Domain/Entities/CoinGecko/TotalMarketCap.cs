using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class TotalMarketCap
    {
        [JsonPropertyName("usd")]
        public decimal Usd { get; set; }
    }
}