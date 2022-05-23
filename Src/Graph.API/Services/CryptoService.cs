using Graph.API.General;
using Graph.API.Models;
using Graph.API.Models.CoinGecko;
using Graph.API.Providers;
using Graph.API.Services.Interfaces;
using Graph.DataAccess.Services.Interfaces;
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

                CryptoAsset? cryptoAsset = JsonSerializer.Deserialize<CryptoAsset>(jsonResponse);

                return cryptoAsset;
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
        public async Task<GlobalMarketData?> GetGlobalCryptoMarketDataAsync()
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

                return globalMarketData;
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

        public async Task<List<DataAccess.Entities.CryptoAsset>> GetSupportedCryptoAssetsAsync()
        {
            return await _dataAccessService.GetCryptoAssetsLookupAsync();
        }
    }
}
