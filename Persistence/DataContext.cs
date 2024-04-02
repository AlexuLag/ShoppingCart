using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

//Consider use of Identity DBContext for security and login users 
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<ProductStock> ProductsStock { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductCategory>(x => x.HasKey(pc => new { pc.ProductId, pc.CategoryId }));

        //foreign key configuration for product in product category
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.Categories)
            .HasForeignKey(pc => pc.CategoryId);

        //foreign key configuration for category in product category
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(pc => pc.ProductId);

        //foreign key between orders and customers
        modelBuilder.Entity<Order>()
       .HasOne(o => o.Customer)
       .WithMany(c => c.Orders)
       .HasForeignKey(o => o.CustomerId);


        //foreign key between orders and order details
        modelBuilder.Entity<Order>()
            .HasMany(or => or.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        //foreign key between order details and products
        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

       //foreign key between product and product stock
        modelBuilder.Entity<Product>()
    .HasOne(p => p.ProductStock)
    .WithOne(ps => ps.Product)
    .HasForeignKey<ProductStock>(ps => ps.ProductId);



    }

}
