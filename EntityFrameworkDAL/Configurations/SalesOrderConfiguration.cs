using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.Property(e => e.Date).HasColumnType("date");

            builder.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.ShipInfo)
                .WithMany(p => p.SalesOrders)
                .HasForeignKey(d => d.ShipInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SalesOrders_ShipInfo");

            new SalesOrderSeeder().Seed(builder);
        }
    }
}