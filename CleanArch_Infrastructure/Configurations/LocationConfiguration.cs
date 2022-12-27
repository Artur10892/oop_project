using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(e => e.City).HasMaxLength(20);

            builder.Property(e => e.LocalAddress).HasMaxLength(20);

            builder.HasOne(d => d.RegionNavigation)
                .WithMany(p => p.Locations)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Location_Region");
            
            new LocationSeeder().Seed(builder);
        }
    }
}