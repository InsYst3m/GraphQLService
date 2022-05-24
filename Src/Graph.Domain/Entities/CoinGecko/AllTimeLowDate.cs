using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class AllTimeLowDate
    {
        [JsonPropertyName("usd")]
        public DateTime UsdDateTime { get; set; }
    }
}