using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(255);

            builder.Property(e => e.Name).HasMaxLength(40);

            builder.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
            
            builder.Property(e => e.SellPrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Category");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Supplier");
            
            new ProductSeeder().Seed(builder);
        }
    }
}