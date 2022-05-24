using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class AllTimeLowChangePercentage : Currency
    {
        [JsonIgnore]
        public string Percentage => $"{Usd}%";
    }
}