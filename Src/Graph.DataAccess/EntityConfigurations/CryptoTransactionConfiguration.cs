using Graph.Domain.Entities.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graph.DataAccess.EntityConfigurations
{
    public class CryptoTransactionConfiguration : IEntityTypeConfiguration<CryptoTransaction>
    {
        public void Configure(EntityTypeBuilder<CryptoTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();
        }
    }
}
