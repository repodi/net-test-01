using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        #region User
        
        modelBuilder.Entity<User>()
            .HasOne<Branch>()
            .WithMany()
            .HasForeignKey(u => u.BranchId);

        modelBuilder.Entity<User>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(u => u.CustomerId);

        #endregion User
        
        #region Price

        modelBuilder.Entity<Price>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(u => u.ProductId);

        modelBuilder.Entity<Price>()
            .HasOne<Unit>()
            .WithMany()
            .HasForeignKey(u => u.UnitId);

        #endregion Price     
        
        #region PurchaseOrder

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(u => u.CustomerId);

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.CustomerId);

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne<Branch>()
            .WithMany()
            .HasForeignKey(u => u.BranchId);

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.BranchUserId);

        #endregion PurchaseOrder

        #region PurchaseOrderProduct

        modelBuilder.Entity<PurchaseOrderProduct>()
            .HasOne<PurchaseOrder>()
            .WithMany()
            .HasForeignKey(u => u.PurchaseOrderId);

        modelBuilder.Entity<PurchaseOrderProduct>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(u => u.ProductId);

        modelBuilder.Entity<PurchaseOrderProduct>()
            .HasOne<Price>()
            .WithMany()
            .HasForeignKey(u => u.PriceId);

        modelBuilder.Entity<PurchaseOrderProduct>()
            .HasOne<Unit>()
            .WithMany()
            .HasForeignKey(u => u.UnitId);

        #endregion PurchaseOrderProduct

        #region Sale

        modelBuilder.Entity<Sale>()
            .HasOne<PurchaseOrder>()
            .WithMany()
            .HasForeignKey(u => u.PurchaseOrderId);

        modelBuilder.Entity<Sale>()
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(u => u.CustomerId);

        modelBuilder.Entity<Sale>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.CustomerUserId);

        modelBuilder.Entity<Sale>()
            .HasOne<Branch>()
            .WithMany()
            .HasForeignKey(u => u.BranchId);

          modelBuilder.Entity<Sale>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(u => u.BranchUserId);

        #endregion Sale

        #region SaleProduct

        modelBuilder.Entity<SaleProduct>()
            .HasOne<PurchaseOrder>()
            .WithMany()
            .HasForeignKey(u => u.SaleId);

        modelBuilder.Entity<SaleProduct>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(u => u.ProductId);

        modelBuilder.Entity<SaleProduct>()
            .HasOne<Price>()
            .WithMany()
            .HasForeignKey(u => u.PriceId);

        modelBuilder.Entity<SaleProduct>()
            .HasOne<Unit>()
            .WithMany()
            .HasForeignKey(u => u.UnitId);

        #endregion SaleProduct


    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}