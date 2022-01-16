using Graph.API.General;
using Graph.API.Models;
using Graph.API.Services.Interfaces;

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

        public Task<CryptoAsset> GetCryptoAssetAsync(string abbreviation)
        {
            return Task.FromResult(new CryptoAsset
            {
                Abbreviation = "BTC",
                Name = "Bitcoin"
            });
        }

        public Task<List<CryptoAsset>> GetCryptoAssetsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
