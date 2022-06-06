using Graph.Domain.Entities.Database;

namespace Graph.DataAccess.Services.Interfaces
{
    public interface IDataAccessService
    {
        Task<List<CryptoAsset>> GetCryptoAssetsLookupAsync();
    }
}
