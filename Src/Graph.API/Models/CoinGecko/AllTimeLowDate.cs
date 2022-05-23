using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class AllTimeLowDate
    {
        [JsonPropertyName("usd")]
        public DateTime UsdDateTime { get; set; }
    }
}