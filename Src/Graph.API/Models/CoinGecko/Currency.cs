﻿using System.Text.Json.Serialization;

namespace Graph.API.Models.CoinGecko
{
    public class Currency
    {
        [JsonPropertyName("usd")]
        public decimal Usd { get; set; }

        [JsonPropertyName("eur")]
        public decimal Euro { get; set; }
    }
}
