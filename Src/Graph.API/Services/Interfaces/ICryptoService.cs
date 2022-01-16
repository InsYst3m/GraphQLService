using Graph.API.Models;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<List<CryptoAsset>> GetCryptoAssetsAsync();
        Task<CryptoAsset> GetCryptoAssetAsync(string abbreviation);
    }
}
