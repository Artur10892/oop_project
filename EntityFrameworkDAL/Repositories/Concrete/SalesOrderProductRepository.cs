using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDAL.Repositories.Concrete
{
    public class SalesOrderProductRepository : GenericRepository<SalesOrderProduct>, ISalesOrderProductRepository
    {
        public SalesOrderProductRepository(InventoryManagementDbContext dBContext) : base(dBContext)
        {
        }
        
        public async Task<IEnumerable<SalesOrderProduct>> GetBySalesOrderIdAsync(int salesOrderId)
        {
            return await Table
                .Where(orderProduct => orderProduct.SalesOrderId == salesOrderId)
                .ToListAsync();
        }
        
        public async Task InsertRangeAsync(IEnumerable<SalesOrderProduct> products)
        {
            await Table.AddRangeAsync(products);
        }
    }
}
