using Graph.DataAccess.Entities;
using Graph.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Graph.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<CryptoAsset> CryptoAssets { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CryptoAssetsConfiguration());
        }
    }
}
