using Graph.API.General;
using Graph.API.Models;
using Graph.API.Services.Interfaces;
using System.Text.Json;

namespace Graph.API.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            _httpClient = httpClientFactory.CreateClient(Constants.HTTP_CLIENT_COIN_GECKO_KEY);
        }
        
        public async Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId)
        {
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
    }
}
