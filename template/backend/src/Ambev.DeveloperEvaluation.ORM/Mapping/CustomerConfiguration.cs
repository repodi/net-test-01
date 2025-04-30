using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.HasData(
            new Customer{
                Id= new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40"), 
                Phone = "1111111111", 
                Email = "mail@mail.com", 
                Name = "customer 1",
                CreatedAt = DateTime.UtcNow
            },
            new Customer{
                Id= new Guid("605b5fa5-3b1c-4b25-92de-1c46ffe19fa1"), 
                Phone = "1111111111", 
                Email = "mail@mail.com", 
                Name = "customer 2",
                CreatedAt = DateTime.UtcNow
            },
            new Customer{
                Id= new Guid("b92201f4-b459-45d5-9ef3-1d9455bf123f"), 
                Phone = "1111111111", 
                Email = "mail@mail.com", 
                Name = "customer 3",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}
