using Graph.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graph.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<CryptoAsset> CryptoAsset { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
