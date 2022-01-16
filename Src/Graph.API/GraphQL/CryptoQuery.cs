using Graph.API.Models;
using Graph.API.Services.Interfaces;

namespace Graph.API.GraphQL
{
    public class CryptoQuery
    {
        public async Task<CryptoAsset?> GetCryptoAssetAsync([Service] ICryptoService cryptoService)
        {
            return await cryptoService.GetCryptoAssetAsync("bitcoin");
        }
    }
}
