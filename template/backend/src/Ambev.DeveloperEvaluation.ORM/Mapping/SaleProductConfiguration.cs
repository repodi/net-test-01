using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SaleProduct");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.ProductId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.PriceId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.UnitId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.FullPrice).IsRequired();
    }
}
