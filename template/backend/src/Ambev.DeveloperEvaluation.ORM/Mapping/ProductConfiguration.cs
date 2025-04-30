using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).HasMaxLength(200);
        builder.Property(u => u.Code).IsRequired().HasMaxLength(20);
        builder.Property(u => u.BarCodeGTIN).HasMaxLength(20);

         builder.HasData(
            new Product{
                Id= new Guid("8c4de8ee-752d-4628-98d2-c4e41ba4d871"), 
                Name = "Agua Tonica Lata 350Ml Antartica", 
                Description = "Agua Tonica",
                BarCodeGTIN = "7891991000840",
                Code = "1201048",
                CreatedAt = DateTime.UtcNow
            },
            new Product{
                Id= new Guid("996c81d9-6726-471b-9e47-8b1009e0691b"), 
                Name = "Cha Tea Zero 1,5Lt Lipton Limao", 
                Description = "Cha gelado",
                BarCodeGTIN = "7891042000201",
                Code = "1121285",
                CreatedAt = DateTime.UtcNow
            },
            new Product{
                Id= new Guid("ff41c778-3de5-4148-a71b-31babac65964"), 
                Name = "Isotonico Gatorade 500Ml Blueberry", 
                Description = "Isotonico",
                BarCodeGTIN = "7892840822019",
                Code = "1277098",
                CreatedAt = DateTime.UtcNow
            }
        );

    }
}
