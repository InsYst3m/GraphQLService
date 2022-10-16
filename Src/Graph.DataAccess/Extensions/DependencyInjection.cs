using Graph.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Graph.DataAccess.Extensions
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
		{
			services.AddPooledDbContextFactory<CryptoAssetsDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			return services;
		}
	}
}
