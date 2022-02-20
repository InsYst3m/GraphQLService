using Graph.API.Models;
using Graph.API.Models.CoinGecko;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId);
        Task<GlobalMarketData?> GetGlobalCryptoMarketDataAsync();
    }
}
