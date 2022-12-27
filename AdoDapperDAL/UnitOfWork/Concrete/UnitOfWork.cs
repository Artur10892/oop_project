using AdoDapperDAL.Repositories.Abstract;
using AdoDapperDAL.UnitOfWork.Abstract;

namespace AdoDapperDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPurchaseOrderRepository PurchaseOrderRepository { get; }
        
        public IPurchaseOrderProductRepository PurchaseOrderProductRepository { get; }
        
        public IWarehouseProductRepository WarehouseProductRepository { get; }

        public IWarehouseRepository WarehouseRepository { get; }

        public UnitOfWork(
            IPurchaseOrderRepository purchaseOrderRepository, 
            IPurchaseOrderProductRepository purchaseOrderProductRepository,
            IWarehouseProductRepository warehouseProductRepository, 
            IWarehouseRepository warehouseRepository)
        {
            PurchaseOrderRepository = purchaseOrderRepository;
            PurchaseOrderProductRepository = purchaseOrderProductRepository;
            WarehouseProductRepository = warehouseProductRepository;
            WarehouseRepository = warehouseRepository;
        }
    }
}
