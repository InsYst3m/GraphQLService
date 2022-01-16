namespace Graph.API.Configuration
{
    public class CoinGeckoSettings
    {
        public const string SECTION_NAME = "CoinGeckoAPI";

        public string BaseAddress { get; set; } = string.Empty;
    }
}
