using Graph.API.General;
using Graph.API.Providers;
using Graph.API.Services.Interfaces;
using Graph.API.ViewModels;
using Graph.DataAccess.Services.Interfaces;
using Graph.Domain.Entities.CoinGecko;
using System.Text.Json;

namespace Graph.API.Services
{
    public class CryptoService : ICryptoService
    {
        private const string GET_CRYPTO_ASSET_ROUTE = "coins/{0}?localization={1:L}&tickers={2:L}&market_data={3:L}&community_data={4:L}&developer_data={5:L}&sparkline={6:L}";

        private readonly HttpClient _httpClient;
        private readonly IDataAccessService _dataAccessService;

        public CryptoService(IHttpClientFactory httpClientFactory, IDataAccessService dataAccessService)
        {
            _ = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _dataAccessService = dataAccessService ?? throw new ArgumentNullException(nameof(dataAccessService));

            _httpClient = httpClientFactory.CreateClient(Constants.HTTP_CLIENT_COIN_GECKO_KEY);
        }
        
        public async Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId)
        {
            bool useLocalization = false;
            bool useTickers = false;
            bool useMarketData = true;
            bool useCommunityData = false;
            bool useDeveloperData = false;
            bool useSparkline = false;
            string jsonResponse = string.Empty;

            try
            {
                string route = 
                    string.Format(
                        new CustomFormatProvider(),
                        GET_CRYPTO_ASSET_ROUTE,
                        geckoId, useLocalization, useTickers, useMarketData, useCommunityData, useDeveloperData, useSparkline);
                
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(route);
                jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                httpResponseMessage.EnsureSuccessStatusCode();

                CryptoAssetData? cryptoAssetData = JsonSerializer.Deserialize<CryptoAssetData>(jsonResponse);

                if (cryptoAssetData is null)
                {
                    return null;
                }

                return new CryptoAsset
                {
                    Abbreviation = cryptoAssetData.Abbreviation,
                    Name = cryptoAssetData.Name,
                    CurrentPriceUsd = cryptoAssetData.MarketData?.CurrentPrice?.Usd ?? 0,
                    CapitalizationUsd = cryptoAssetData.MarketData?.MarketCap?.Usd ?? 0,
                    Rank = cryptoAssetData.MarketData?.MarketCapRank ?? 0,

                    HighTwentyFourHoursUsd = cryptoAssetData.MarketData?.HighTwentyFourHours?.Usd ?? 0,
                    AllTimeHighPriceUsd = cryptoAssetData.MarketData?.AllTimeHigh?.Usd ?? 0,
                    AllTimeHighDate = cryptoAssetData.MarketData?.AllTimeHighDate?.UsdDateTime ?? DateTime.MinValue,
                    AllTimeHighChangePercentage = 
                        cryptoAssetData.MarketData?.AllTimeHighChangePercentage is not null
                            ? $"{cryptoAssetData.MarketData.AllTimeHighChangePercentage.Usd}%"
                            : string.Empty,

                    LowTwentyFourHoursUsd = cryptoAssetData.MarketData?.LowTwentyFourHours?.Usd ?? 0,
                    AllTimeLowPriceUsd = cryptoAssetData.MarketData?.AllTimeLow?.Usd ?? 0,
                    AllTimeLowDate = cryptoAssetData.MarketData?.AllTimeLowDate?.UsdDateTime ?? DateTime.MinValue,
                    AllTimeLowChangePercentage =
                        cryptoAssetData.MarketData?.AllTimeLowChangePercentage is not null
                            ? $"{cryptoAssetData.MarketData.AllTimeLowChangePercentage.Usd}%"
                            : string.Empty,

                    PriceChangePercentageTwentyFourHours =
                        cryptoAssetData.MarketData?.PriceChangePercentageTwentyFourHours is not null
                            ? $"{cryptoAssetData.MarketData.PriceChangePercentageTwentyFourHours}%"
                            : string.Empty,

                    PriceChangePercentageSevenDays = 
                        cryptoAssetData.MarketData?.PriceChangePercentageSevenDays is not null
                            ? $"{cryptoAssetData.MarketData.PriceChangePercentageSevenDays}%"
                            : string.Empty,

                    PriceChangePercentageThirtyDays =
                        cryptoAssetData.MarketData?.PriceChangePercentageThirtyDays is not null
                            ? $"{cryptoAssetData.MarketData.PriceChangePercentageThirtyDays}%"
                            : string.Empty,

                    PriceChangePercentageSixtyDays =
                        cryptoAssetData.MarketData?.PriceChangePercentageSixtyDays is not null
                            ? $"{cryptoAssetData.MarketData.PriceChangePercentageSixtyDays}%"
                            : string.Empty,

                    PriceChangePercentageOneYear =
                        cryptoAssetData.MarketData?.PriceChangePercentageOneYear is not null
                            ? $"{cryptoAssetData.MarketData.PriceChangePercentageOneYear}%"
                            : string.Empty
                };
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    ex.Data.Add("JsonResponse", jsonResponse);
                }

                throw;
            }
        }

        /// <inheritdoc cref="ICryptoService.GetGlobalCryptoMarketDataAsync"/>
        public async Task<GlobalMarket?> GetGlobalCryptoMarketDataAsync()
        {
            // https://api.coingecko.com/api/v3/global
            string route = $"global";
            string jsonResponse = string.Empty;

            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(route);
                jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                httpResponseMessage.EnsureSuccessStatusCode();

                GlobalMarketData? globalMarketData = JsonSerializer.Deserialize<GlobalMarketData>(jsonResponse);

                if (globalMarketData is null)
                {
                    return null;
                }

                return new GlobalMarket
                {
                    ActiveCryptoCurrencies = globalMarketData.Data.ActiveCryptoCurrencies,
                    CapitalizationUsd = globalMarketData.Data.TotalMarketCap.Usd
                };
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(jsonResponse))
                {
                    ex.Data.Add("JsonResponse", jsonResponse);
                }

                throw;
            }
        }

        public async Task<List<Domain.Entities.Database.CryptoAsset>> GetSupportedCryptoAssetsAsync()
        {
            return await _dataAccessService.GetCryptoAssetsLookupAsync();
        }
    }
}
