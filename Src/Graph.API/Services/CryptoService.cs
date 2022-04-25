using Graph.API.General;
using Graph.API.Models;
using Graph.API.Models.CoinGecko;
using Graph.API.Services.Interfaces;
using Graph.DataAccess.Services.Interfaces;
using System.Text.Json;

namespace Graph.API.Services
{
    public class CryptoService : ICryptoService
    {
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
            // https://api.coingecko.com/api/v3/coins/bitcoin
            string route = $"coins/{geckoId}";
            string jsonResponse = string.Empty;

            try
            {
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
    }
}
