﻿using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class AllTimeLowChangePercentage : Currency
    {
        [JsonIgnore]
        public string Percentage => $"{Usd}%";
    }
}