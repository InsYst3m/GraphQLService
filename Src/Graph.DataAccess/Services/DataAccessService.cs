using Graph.DataAccess.Contexts;
using Graph.DataAccess.Services.Interfaces;
using Graph.Domain.Entities.CryptoAssets;

using Microsoft.EntityFrameworkCore;

namespace Graph.DataAccess.Services
{
    public class DataAccessService : IDataAccessService
	{
		private readonly IDbContextFactory<CryptoAssetsDbContext> _dbContextFactory;

		public DataAccessService(IDbContextFactory<CryptoAssetsDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
		}

		public async Task<List<CryptoAsset>> GetCryptoAssetsLookupAsync()
		{
			CryptoAssetsDbContext context = await _dbContextFactory.CreateDbContextAsync();

			return context.CryptoAssets.ToList();
		}
	}
}
