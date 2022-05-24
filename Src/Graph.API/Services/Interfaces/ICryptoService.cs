using Graph.API.ViewModels;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<DataAccess.Entities.CryptoAsset>> GetSupportedCryptoAssetsAsync();
        Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId);
        Task<GlobalMarket?> GetGlobalCryptoMarketDataAsync();
    }
}
