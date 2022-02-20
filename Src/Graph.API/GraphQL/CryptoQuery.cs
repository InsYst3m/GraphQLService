using Graph.API.Models;
using Graph.API.Models.CoinGecko;
using Graph.API.Services.Interfaces;

namespace Graph.API.GraphQL
{
    public class CryptoQuery
    {
        private readonly Dictionary<string, string> _cryptoAssetsLookup = new()
        {
            { "btc", "bitcoin" },
            { "eth", "ethereum" },
            { "xrp", "ripple" },
            { "dot", "polkadot" },
            { "atom", "cosmos" },
            { "cro", "crypto-com-chain" },
            { "link", "chainlink" },
            { "near", "near" },
            { "uni", "unicorn-token" },
            { "xlm", "stellar" }
        };

        public async Task<CryptoAsset?> GetCryptoAssetAsync([Service] ICryptoService cryptoService, string abbreviation)
        {
            _cryptoAssetsLookup.TryGetValue(abbreviation, out string? geckoId);

            if (geckoId == null)
            {
                return null;
            }

            return await cryptoService.GetCryptoAssetAsync(geckoId);
        }

        public List<string> GetAbbreviations()
        {
            List<string> abbreviations = _cryptoAssetsLookup.Select(x => x.Key).ToList();

            return abbreviations;
        }

        public async Task<GlobalMarketData?> GetGlobalCryptoMarketDataAsync([Service] ICryptoService cryptoService)
        {
            return await cryptoService.GetGlobalCryptoMarketDataAsync();
        }
    }
}
