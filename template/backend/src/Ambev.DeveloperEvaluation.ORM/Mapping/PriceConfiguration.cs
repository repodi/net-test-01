using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable("Price");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(u => u.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.UnitId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).HasMaxLength(200);
    }
}
