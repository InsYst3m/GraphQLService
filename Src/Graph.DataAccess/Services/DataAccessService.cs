using Graph.DataAccess.Services.Interfaces;
using Graph.Domain.Entities.Database;
using Microsoft.EntityFrameworkCore;

namespace Graph.DataAccess.Services
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public DataAccessService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public async Task<List<CryptoAsset>> GetCryptoAssetsLookupAsync()
        {
            AppDbContext context = await _dbContextFactory.CreateDbContextAsync();

            return context.CryptoAssets.ToList();
        }
    }
}
