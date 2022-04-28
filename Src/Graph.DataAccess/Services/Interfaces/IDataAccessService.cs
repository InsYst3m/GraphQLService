using Graph.DataAccess.Entities;

namespace Graph.DataAccess.Services.Interfaces
{
    public interface IDataAccessService
    {
        Task<List<CryptoAsset>> GetCryptoAssetsLookupAsync();
    }
}
