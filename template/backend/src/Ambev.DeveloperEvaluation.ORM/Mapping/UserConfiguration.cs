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

        builder.Property(u => u.BranchId).HasColumnType("uuid");
        builder.Property(u => u.CustomerId).HasColumnType("uuid");
        builder.Property(u => u.SellerCode).HasMaxLength(20);
        
        builder.HasData(
            new User { 
                Id= new Guid("41e3de69-4265-43c6-a2d1-9657979160d2"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "developer", 
                Phone = "1111111111", 
                Email = "developer@mail.com", 
                Role = Domain.Enums.UserRole.Admin , 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow
            },
            new User { 
                Id= new Guid("d7081c09-0bba-4728-b4e5-804c73a6d1b8"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "admin", 
                Phone = "1111111111", 
                Email = "admin@mail.com", 
                Role = Domain.Enums.UserRole.Admin , 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow
            },
            new User { 
                Id= new Guid("f16dcf3f-c13c-413a-a73d-cc297c0e53a0"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "manager", 
                Phone = "1111111111", 
                Email = "manager@mail.com", 
                Role = Domain.Enums.UserRole.Manager , 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow
            },
            new User { 
                Id= new Guid("24315cc0-f77d-48ae-a0c1-56cfa851491a"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "branch1-user1", 
                Phone = "1111111111", 
                Email = "branch1user1@mail.com", 
                Role = Domain.Enums.UserRole.Branch,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                BranchId = new Guid("e46bb862-2076-4d46-9155-749f48648f2e")
            },
            new User { 
                Id= new Guid("98004d1c-87c7-40d4-b873-43aa8524bbf7"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "branch1-user2", 
                Phone = "1111111111", 
                Email = "branch1user2@mail.com", 
                Role = Domain.Enums.UserRole.Branch,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                BranchId = new Guid("e46bb862-2076-4d46-9155-749f48648f2e")
            },
            new User { 
                Id= new Guid("f43616fd-c39e-40aa-b57f-b97c3937d849"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "branch2-user1", 
                Phone = "1111111111", 
                Email = "branch2user1@mail.com", 
                Role = Domain.Enums.UserRole.Branch,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                BranchId= new Guid("9d84f0d1-38fa-473a-a06f-2281ca179f51") 
            },
            new User { 
                Id= new Guid("51372e2d-00ed-475f-9cbb-f8debff265b4"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "customer1-user1", 
                Phone = "1111111111", 
                Email = "customer1user1@mail.com", 
                Role = Domain.Enums.UserRole.Customer,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                CustomerId= new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40")
            },
            new User { 
                Id= new Guid("5640e90f-ddc7-497f-821e-7aff79c34238"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "customer1-user2", 
                Phone = "1111111111", 
                Email = "customer1user2@mail.com", 
                Role = Domain.Enums.UserRole.Customer,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                CustomerId= new Guid("d78d9a8d-bbc1-46c3-b4c3-0a2798f74c40")
            },
            new User { 
                Id= new Guid("8320f1b2-32a2-409f-88df-bd60a83723de"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "customer2-user1", 
                Phone = "1111111111", 
                Email = "customer2user1@mail.com", 
                Role = Domain.Enums.UserRole.Customer,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                CustomerId= new Guid("605b5fa5-3b1c-4b25-92de-1c46ffe19fa1"), 
            },
            new User { 
                Id= new Guid("a28d70c5-1b17-4913-87e6-e1e18f65571b"), 
                Password="$2a$11$kYfspCSu4jJk55A/NynhtOahhlgPwki3SSlyusVQTjqZ.rLYbIrg.",  
                Username = "customer3-user1", 
                Phone = "1111111111", 
                Email = "customer3user1@mail.com", 
                Role = Domain.Enums.UserRole.Customer,                 
                Status = Domain.Enums.UserStatus.Active, 
                CreatedAt = DateTime.UtcNow,
                CustomerId= new Guid("b92201f4-b459-45d5-9ef3-1d9455bf123f"), 
            }
        );

    }
}
