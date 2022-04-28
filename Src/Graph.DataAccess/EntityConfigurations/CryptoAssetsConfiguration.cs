using Graph.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graph.DataAccess.EntityConfigurations
{
    public class CryptoAssetsConfiguration : IEntityTypeConfiguration<CryptoAsset>
    {
        public void Configure(EntityTypeBuilder<CryptoAsset> builder)
        {
            builder.Property(asset => asset.Id)
                .IsRequired()
                .UseIdentityColumn();
        }
    }
}
