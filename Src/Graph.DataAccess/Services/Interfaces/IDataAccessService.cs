using Graph.Domain.Entities.CryptoAssets;

namespace Graph.DataAccess.Services.Interfaces
{
	public interface IDataAccessService
    {
        Task<List<CryptoAsset>> GetCryptoAssetsLookupAsync();
    }
}
