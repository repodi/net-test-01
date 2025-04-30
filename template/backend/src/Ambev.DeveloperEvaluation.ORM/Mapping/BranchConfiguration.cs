using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("Branch");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.HasData(
            new Branch{
                Id= new Guid("e46bb862-2076-4d46-9155-749f48648f2e"), 
                Phone = "1111111111", 
                Email = "mail@mail.com", 
                Name = "branch 1",
                CreatedAt = DateTime.UtcNow
            },
            new Branch{
                Id= new Guid("9d84f0d1-38fa-473a-a06f-2281ca179f51"), 
                Phone = "1111111111", 
                Email = "mail@mail.com", 
                Name = "branch 2",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}
