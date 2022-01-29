using Graph.API.Models;

namespace Graph.API.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<CryptoAsset?> GetCryptoAssetAsync(string geckoId);
    }
}
