using EntityFrameworkDAL.Configurations;
using EntityFrameworkDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkDAL
{
    public class InventoryManagementDbContext : DbContext
    {
        public InventoryManagementDbContext()
        {
            
        }

        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public virtual DbSet<SalesOrderProduct> SalesOrderProducts { get; set; } = null!;
        public virtual DbSet<ShipInfo> ShipInfos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));
            //optionsBuilder.UseSqlServer(@"Server=localhost,1433;Initial Catalog=InventoryManagementDB;User ID=SA;Password=Strong.Pwd-123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");
            
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
            modelBuilder.ApplyConfiguration(new SalesOrderProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShipInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
