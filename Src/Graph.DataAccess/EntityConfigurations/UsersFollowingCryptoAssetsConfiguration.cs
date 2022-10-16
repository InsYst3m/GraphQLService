using Graph.Domain.Entities.CryptoAssets;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graph.DataAccess.EntityConfigurations
{
	public class UsersFollowingCryptoAssetsConfiguration : IEntityTypeConfiguration<UsersFollowingCryptoAssets>
    {
        public void Configure(EntityTypeBuilder<UsersFollowingCryptoAssets> builder)
        {
            builder.HasKey(x => new { x.UserId, x.CryptoAssetId });
        }
    }
}
