using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Configurations
{
    public class ShipInfoConfiguration : IEntityTypeConfiguration<ShipInfo>
    {
        public void Configure(EntityTypeBuilder<ShipInfo> builder)
        {
            builder.ToTable("ShipInfo");

            builder.HasOne(d => d.CustomerUser)
                .WithMany(p => p.ShipInfos)
                .HasForeignKey(d => d.CustomerUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ShipInfos_CustomerUser");

            new ShipInfoSeeder().Seed(builder);
        }
    }
}