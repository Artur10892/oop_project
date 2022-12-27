using EntityFrameworkDAL.Repositories.Abstract;
using EntityFrameworkDAL.UnitOfWork.Abstract;

namespace EntityFrameworkDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public InventoryManagementDbContext DbContext { get; }
        
        public IUserRepository UserRepository { get; }
        
        public ICustomerRepository CustomerRepository { get; }
        
        public ISalesOrderRepository SalesOrderRepository { get; }
        
        public ISalesOrderProductRepository SalesOrderProductRepository { get; }
        
        public IShipInfoRepository ShipInfoRepository { get; }

        public UnitOfWork(
            InventoryManagementDbContext dbContext,
            IUserRepository userRepository, 
            ICustomerRepository customerRepository, 
            ISalesOrderRepository salesOrderRepository, 
            IShipInfoRepository shipInfoRepository, 
            ISalesOrderProductRepository salesOrderProductRepository)
        {
            DbContext = dbContext;
            UserRepository = userRepository;
            CustomerRepository = customerRepository;
            SalesOrderRepository = salesOrderRepository;
            ShipInfoRepository = shipInfoRepository;
            SalesOrderProductRepository = salesOrderProductRepository;
        }
        
        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
