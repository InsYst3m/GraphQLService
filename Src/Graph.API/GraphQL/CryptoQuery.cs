using Graph.API.Services.Interfaces;
using Graph.API.ViewModels;
using Graph.Domain.Entities.CryptoAssets;

namespace Graph.API.GraphQL
{
	public class CryptoQuery
	{
		public async Task<List<string>> GetSupportedCryptoAssets([Service] ICryptoService cryptoService)
		{
			List<CryptoAsset> cryptoAssetsLookup = 
				await cryptoService.GetSupportedCryptoAssetsAsync();

			return cryptoAssetsLookup
				.Select(x => x.Abbreviation)
				.ToList();
		}

		public async Task<CryptoAssetViewModel?> GetCryptoAssetAsync([Service] ICryptoService cryptoService, string abbreviation)
		{
			List<CryptoAsset> cryptoAssetsLookup = await cryptoService.GetSupportedCryptoAssetsAsync();

			if (!cryptoAssetsLookup.Any())
			{
				return null;
			}

			CryptoAsset? cryptoAsset = cryptoAssetsLookup
				.FirstOrDefault(x => x.Abbreviation.Equals(abbreviation, StringComparison.InvariantCultureIgnoreCase));

			if (cryptoAsset == null)
			{
				return null;
			}

			return await cryptoService.GetCryptoAssetAsync(cryptoAsset.CoinGeckoAbbreviation);
		}

		public async Task<GlobalMarketViewModel?> GetGlobalCryptoMarketDataAsync([Service] ICryptoService cryptoService)
		{
			return await cryptoService.GetGlobalCryptoMarketDataAsync();
		}
	}
}
