using Graph.API.ViewModels;
using Graph.Domain.Entities.CryptoAssets;

namespace Graph.API.Services.Interfaces
{
	public interface ICryptoService
	{
		/// <summary>
		/// Get list of supported crypto assets from the database.
		/// </summary>
		/// <returns>
		/// List with the supported crypto assets or empty list.
		/// </returns>
		Task<List<CryptoAsset>> GetSupportedCryptoAssetsAsync();

		Task<CryptoAssetViewModel?> GetCryptoAssetAsync(string geckoId);
		Task<GlobalMarketViewModel?> GetGlobalCryptoMarketDataAsync();
	}
}
