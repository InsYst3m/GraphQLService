using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public CurrentPrice? CurrentPrice { get; set; }

        [JsonPropertyName("ath")]
        public AllTimeHigh? AllTimeHigh { get; set; }

        [JsonPropertyName("ath_change_percentage")]
        public AllTimeHighChangePercentage? AllTimeHighChangePercentage { get; set; }

        [JsonPropertyName("ath_date")]
        public AllTimeHighDate? AllTimeHighDate { get; set; }

        [JsonPropertyName("atl")]
        public AllTimeLow? AllTimeLow { get; set; }

        [JsonPropertyName("atl_change_percentage")]
        public AllTimeLowChangePercentage? AllTimeLowChangePercentage { get; set; }

        [JsonPropertyName("atl_date")]
        public AllTimeLowDate? AllTimeLowDate { get; set; }

        [JsonPropertyName("market_cap")]
        public MarketCap? MarketCap { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public long MarketCapRank { get; set; }

        [JsonPropertyName("high_24h")]
        public HighTwentyFourHours? HighTwentyFourHours { get; set; }

        [JsonPropertyName("low_24h")]
        public LowTwentyFourHours? LowTwentyFourHours { get; set; }

        [GraphQLIgnore]
        [JsonPropertyName("price_change_percentage_24h")]
        public decimal PriceChangePercentageTwentyFourHours { get; set; }

        [JsonIgnore]
        public string PriceChangeTwentyFourHoursPercentage => $"{PriceChangePercentageTwentyFourHours}%";

        [GraphQLIgnore]
        [JsonPropertyName("price_change_percentage_7d")]
        public decimal PriceChangePercentageSevenDays { get; set; }

        [JsonIgnore]
        public string PriceChangeSevenDaysPercentage => $"{PriceChangePercentageSevenDays}%";

        [GraphQLIgnore]
        [JsonPropertyName("price_change_percentage_30d")]
        public decimal PriceChangePercentageThirtyDays { get; set; }

        [JsonIgnore]
        public string PriceChangeThirtyDaysPercentage => $"{PriceChangePercentageThirtyDays}%";

        [GraphQLIgnore]
        [JsonPropertyName("price_change_percentage_60d")]
        public decimal PriceChangePercentageSixtyDays { get; set; }

        [JsonIgnore]
        public string PriceChangeSixtyDaysPercentage => $"{PriceChangePercentageSixtyDays}%";

        [GraphQLIgnore]
        [JsonPropertyName("price_change_percentage_1y")]
        public decimal PriceChangePercentageOneYear { get; set; }

        [JsonIgnore]
        public string PriceChangeOneYearPercentage => $"{PriceChangePercentageOneYear}%";
    }
}
