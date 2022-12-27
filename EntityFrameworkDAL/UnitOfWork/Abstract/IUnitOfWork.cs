using EntityFrameworkDAL.Repositories.Abstract;

namespace EntityFrameworkDAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public InventoryManagementDbContext DbContext { get; }
        
        public IUserRepository UserRepository { get; }
        
        public ICustomerRepository CustomerRepository { get; }
        
        public ISalesOrderRepository SalesOrderRepository { get; }
        
        public ISalesOrderProductRepository SalesOrderProductRepository { get; }
        
        public IShipInfoRepository ShipInfoRepository { get; }

        Task SaveChangesAsync();
    }
}
