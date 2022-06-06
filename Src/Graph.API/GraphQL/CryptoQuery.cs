using Graph.API.Services.Interfaces;
using Graph.API.ViewModels;

namespace Graph.API.GraphQL
{
    public class CryptoQuery
    {
        public async Task<List<string>> GetSupportedCryptoAssets([Service] ICryptoService cryptoService)
        {
            var cryptoAssetsLookup = await cryptoService.GetSupportedCryptoAssetsAsync();

            if (cryptoAssetsLookup == null || !cryptoAssetsLookup.Any())
            {
                return new List<string>();
            }

            return cryptoAssetsLookup.Select(x => x.Abbreviation).ToList();
        }

        public async Task<CryptoAsset?> GetCryptoAssetAsync([Service] ICryptoService cryptoService, string abbreviation)
        {
            List<Domain.Entities.Database.CryptoAsset> cryptoAssetsLookup = await cryptoService.GetSupportedCryptoAssetsAsync();

            if (!cryptoAssetsLookup.Any())
            {
                return null;
            }

            var cryptoAsset = cryptoAssetsLookup.FirstOrDefault(x => x.Abbreviation == abbreviation);

            if (cryptoAsset == null)
            {
                return null;
            }

            return await cryptoService.GetCryptoAssetAsync(cryptoAsset.CoinGeckoAbbreviation);
        }

        public async Task<GlobalMarket?> GetGlobalCryptoMarketDataAsync([Service] ICryptoService cryptoService)
        {
            return await cryptoService.GetGlobalCryptoMarketDataAsync();
        }
    }
}
