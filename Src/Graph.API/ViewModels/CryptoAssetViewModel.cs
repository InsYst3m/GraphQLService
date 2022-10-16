namespace Graph.API.ViewModels
{
	public class CryptoAssetViewModel
	{
		public string Name { get; set; } = string.Empty;
		public string Abbreviation { get; set; } = string.Empty;

		public decimal CurrentPriceUsd { get; set; }

		public decimal AllTimeHighPriceUsd { get; set; }
		public string AllTimeHighChangePercentage { get; set; } = string.Empty;
		public DateTime AllTimeHighDate { get; set; }

		public decimal AllTimeLowPriceUsd { get; set; }
		public string AllTimeLowChangePercentage { get; set; } = string.Empty;
		public DateTime AllTimeLowDate { get; set; }

		public decimal CapitalizationUsd { get; set; }
		public long Rank { get; set; }

		public decimal HighTwentyFourHoursUsd { get; set; }
		public decimal LowTwentyFourHoursUsd { get; set; }

		public string PriceChangePercentageTwentyFourHours { get; set; } = string.Empty;
		public string PriceChangePercentageSevenDays { get; set; } = string.Empty;
		public string PriceChangePercentageThirtyDays { get; set; } = string.Empty;
		public string PriceChangePercentageSixtyDays { get; set; } = string.Empty;
		public string PriceChangePercentageOneYear { get; set; } = string.Empty;
	}
}
