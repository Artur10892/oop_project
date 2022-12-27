using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Seeding.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDAL.Configurations
{
    public class SalesOrderProductConfiguration : IEntityTypeConfiguration<SalesOrderProduct>
    {
        public void Configure(EntityTypeBuilder<SalesOrderProduct> builder)
        {
            builder.HasOne(d => d.SalesOrder)
                .WithMany(p => p.SalesOrderProducts)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_SalesOrderProducts_SalesOrder");
            
            new SalesOrderProductSeeder().Seed(builder);
        }
    }
}