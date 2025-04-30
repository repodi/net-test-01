using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class PurchaseOrderProductConfiguration : IEntityTypeConfiguration<PurchaseOrderProduct>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderProduct> builder)
    {
        builder.ToTable("PurchaseOrderProduct");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.PurchaseOrderId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.ProductId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.PriceId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.UnitId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.FullPrice).IsRequired();
    }
}
