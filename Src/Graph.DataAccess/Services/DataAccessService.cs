using Graph.DataAccess.Entities;
using Graph.DataAccess.Services.Interfaces;

namespace Graph.DataAccess.Services
{
    public class DataAccessService : IDataAccessService
    {
        public Task<List<CryptoAsset>> GetSupportedCryptoAssets()
        {
            throw new NotImplementedException();
        }
    }
}
