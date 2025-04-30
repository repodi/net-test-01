using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discount");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.MinimumUnits).IsRequired();
        builder.Property(u => u.DiscountPercentage).IsRequired();

        builder.HasData(
            new Discount{
                Id= new Guid("f0fa1ae7-2801-44ef-8402-5ea4d0c7f8c6"), 
                MinimumUnits = 4,
                DiscountPercentage = 10m, 
                CreatedAt = DateTime.UtcNow
            },
            new Discount{
                Id= new Guid("17c2e1f1-94f9-4d00-bab0-8273aee78790"), 
                MinimumUnits = 10,
                DiscountPercentage = 20m, 
                CreatedAt = DateTime.UtcNow
            },
            new Discount{
                Id= new Guid("b551c293-bb06-4dc4-ae9b-bc4ab7e5fef9"), 
                MinimumUnits = 21,
                DiscountPercentage = 0m, 
                CreatedAt = DateTime.UtcNow
            }
        );
        
    }
}
