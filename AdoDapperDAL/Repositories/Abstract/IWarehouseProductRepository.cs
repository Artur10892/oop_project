using AdoDapperDAL.Entities;

namespace AdoDapperDAL.Repositories.Abstract
{
    public interface IWarehouseProductRepository : IGenericRepository<WarehouseProduct>
    {
        Task<IEnumerable<object>> GetByWarehouseIdAsync(int warehouseId);

        Task<object?> GetByWarehouseAndProductIdsAsync(int warehouseId, int productId);

        Task<int> InsertAsync(IEnumerable<WarehouseProduct> products);

        Task UpdateAsync(IEnumerable<WarehouseProduct> products);
    }
}
