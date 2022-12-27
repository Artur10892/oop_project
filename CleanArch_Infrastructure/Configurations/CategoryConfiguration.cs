using CleanArch_Domain.Entities;
using CleanArch_Infrastructure.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(255);

            builder.Property(e => e.Name).HasMaxLength(20);
            
            new CategorySeeder().Seed(builder);
        }
    }
}