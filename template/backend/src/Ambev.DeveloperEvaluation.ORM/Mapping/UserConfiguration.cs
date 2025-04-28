using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasData(
            new User { Id= new Guid("41e3de69-4265-43c6-a2d1-9657979160d2"), Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  Username = "developer", Phone = "1111111111", Email = "developer@mail.com", Role = Domain.Enums.UserRole.Admin , Status = Domain.Enums.UserStatus.Active, CreatedAt = DateTime.UtcNow}
        );

    }
}
