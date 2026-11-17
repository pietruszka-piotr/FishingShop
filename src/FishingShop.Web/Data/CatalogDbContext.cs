using FishingShop.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingShop.Web.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<RodSpecification> RodSpecifications => Set<RodSpecification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(category => category.Name).HasMaxLength(120);
        modelBuilder.Entity<Brand>().Property(brand => brand.Name).HasMaxLength(120);

        modelBuilder.Entity<Product>(product =>
        {
            product.Property(item => item.Name).HasMaxLength(160);
            product.Property(item => item.Price).HasPrecision(18, 2);
            product.ToTable(table => table.HasCheckConstraint("CK_Products_Price", "[Price] >= 0"));

            product.HasOne(item => item.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(item => item.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            product.HasOne(item => item.Brand)
                .WithMany(brand => brand.Products)
                .HasForeignKey(item => item.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<RodSpecification>(rod =>
        {
            rod.HasKey(specification => specification.ProductId);
            rod.HasOne(specification => specification.Product)
                .WithOne(product => product.RodSpecification)
                .HasForeignKey<RodSpecification>(specification => specification.ProductId);

            rod.Property(specification => specification.CastWeightMinG).HasPrecision(6, 2);
            rod.Property(specification => specification.CastWeightMaxG).HasPrecision(6, 2);
            rod.Property(specification => specification.Type).HasConversion<string>().HasMaxLength(8);

            rod.ToTable(table =>
            {
                table.HasCheckConstraint("CK_RodSpecifications_Length", "[LengthCm] > 0");
                table.HasCheckConstraint("CK_RodSpecifications_CastWeight", "[CastWeightMinG] > 0 AND [CastWeightMaxG] >= [CastWeightMinG]");
                table.HasCheckConstraint("CK_RodSpecifications_Type", "[Type] IN (N'Spinning', N'Casting')");
            });
        });
    }
}
