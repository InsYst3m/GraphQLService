using System.Text.Json.Serialization;

namespace Graph.Domain.Entities.CoinGecko
{
    public class AllTimeHighChangePercentage : Currency
    {
        [JsonIgnore]
        public string Percentage => $"{Usd}%";
    }
}