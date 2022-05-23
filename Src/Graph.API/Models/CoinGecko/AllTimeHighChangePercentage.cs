using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class AllTimeHighChangePercentage : Currency
    {
        [JsonIgnore]
        public string Percentage => $"{Usd}%";
    }
}