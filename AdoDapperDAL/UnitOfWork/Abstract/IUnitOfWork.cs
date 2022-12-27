using AdoDapperDAL.Repositories.Abstract;

namespace AdoDapperDAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IPurchaseOrderRepository PurchaseOrderRepository { get; }
        
        public IPurchaseOrderProductRepository PurchaseOrderProductRepository { get; }
        
        public IWarehouseProductRepository WarehouseProductRepository { get; }
        
        public IWarehouseRepository WarehouseRepository { get; }
    }
}
