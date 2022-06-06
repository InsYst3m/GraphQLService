using Graph.API.ViewModels;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<Domain.Entities.Database.CryptoAsset>> GetSupportedCryptoAssetsAsync();
        Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId);
        Task<GlobalMarket?> GetGlobalCryptoMarketDataAsync();
    }
}
