using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(e => e.CompanyName).HasMaxLength(30);

            builder.Property(e => e.PhoneNum).HasMaxLength(15);

            builder.HasOne(d => d.Location)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Suppliers_Location");
            
            new SupplierSeeder().Seed(builder);
        }
    }
}