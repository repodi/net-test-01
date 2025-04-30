using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.ToTable("PurchaseOrder");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Number).IsRequired();
        builder.Property(u => u.CustomerId).HasColumnType("uuid").IsRequired();
        builder.Property(u => u.CustomerUserId).HasColumnType("uuid");
        builder.Property(u => u.BranchId).HasColumnType("uuid");
        builder.Property(u => u.BranchUserId).HasColumnType("uuid");
        builder.Property(u => u.RecommendedSellerCode).HasMaxLength(20);
        builder.Property(u => u.Information).HasMaxLength(200);
        builder.Property(u => u.Cancelled).HasDefaultValue(false);
        builder.Property(u => u.Open).HasDefaultValue(true);
    }
}
