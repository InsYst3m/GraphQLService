using Graph.API.Models;
using Graph.API.Models.CoinGecko;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<DataAccess.Entities.CryptoAsset>> GetSupportedCryptoAssetsAsync();
        Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId);
        Task<GlobalMarketData?> GetGlobalCryptoMarketDataAsync();
    }
}
