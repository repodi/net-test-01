using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Unit");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).HasMaxLength(200);

        builder.HasData(
            new Unit{
                Id= new Guid("b2b8cb3c-b60e-44b1-a494-f5ce9fad92e1"), 
                Name = "UN",    
                Description = "Unit",            
                CreatedAt = DateTime.UtcNow
            },
            new Unit{
                Id= new Guid("8b3310f7-05cb-4530-917b-f7824edf8584"), 
                Name = "PC",    
                Description = "Package", 
                CreatedAt = DateTime.UtcNow
            }
        );

    }
}
