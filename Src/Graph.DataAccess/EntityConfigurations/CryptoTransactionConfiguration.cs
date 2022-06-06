﻿using Graph.Domain.Entities.Database;
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

            builder
                .Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(6);

            builder
                .Property(x => x.BuyPrice)
                .HasColumnType("decimal")
                .IsRequired()
                .HasPrecision(6);
        }
    }
}
