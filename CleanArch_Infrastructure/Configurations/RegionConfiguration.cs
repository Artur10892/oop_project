using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(20);
            
            new RegionSeeder().Seed(builder);
        }
    }
}