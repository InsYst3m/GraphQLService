using Graph.Domain.Entities.CryptoAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graph.DataAccess.EntityConfigurations
{
	public class CryptoAssetConfiguration : IEntityTypeConfiguration<CryptoAsset>
    {
        public void Configure(EntityTypeBuilder<CryptoAsset> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(asset => asset.Id)
                .IsRequired()
                .UseIdentityColumn();
        }
    }
}
