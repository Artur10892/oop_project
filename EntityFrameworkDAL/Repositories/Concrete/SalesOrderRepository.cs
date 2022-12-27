using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Exceptions;
using EntityFrameworkDAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDAL.Repositories.Concrete
{
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(InventoryManagementDbContext dBContext) : base(dBContext)
        {
        }

        public override async Task<IEnumerable<SalesOrder>> GetAllAsync()
        {
            return await Table
                .Include(salesOrder => salesOrder.ShipInfo)
                    .ThenInclude(shipInfo => shipInfo.CustomerUser)
                        .ThenInclude(customerUser => customerUser.User)
                .ToListAsync();
        }

        public override async Task<SalesOrder> GetByIdAsync(int id)
        {
            var entity = await Table
                .Include(salesOrder => salesOrder.ShipInfo)
                    .ThenInclude(shipInfo => shipInfo.CustomerUser)
                        .ThenInclude(customerUser => customerUser.User)
                .FirstOrDefaultAsync(salesOrder => salesOrder.Id == id);
            
            return entity ?? throw new EntityNotFoundException(nameof(SalesOrder), id);
        }
    }
}
