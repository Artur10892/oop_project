using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.BirthDate).HasColumnType("date");

            builder.Property(e => e.FirstName).HasMaxLength(20);

            builder.Property(e => e.LastName).HasMaxLength(20);
            
            new UserSeeder().Seed(builder);
        }
    }
}