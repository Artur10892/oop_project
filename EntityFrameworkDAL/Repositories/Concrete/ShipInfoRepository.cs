using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Exceptions;
using EntityFrameworkDAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDAL.Repositories.Concrete
{
    public class ShipInfoRepository : GenericRepository<ShipInfo>, IShipInfoRepository
    {
        public ShipInfoRepository(InventoryManagementDbContext dBContext) : base(dBContext)
        {
        }

        public override async Task<IEnumerable<ShipInfo>> GetAllAsync()
        {
            return await Table
                .Include(shipInfo => shipInfo.CustomerUser)
                    .ThenInclude(customerUser => customerUser.User)
                .ToListAsync();
        }

        public override async Task<ShipInfo> GetByIdAsync(int id)
        {
            var entity = await Table
                .Include(shipInfo => shipInfo.CustomerUser)
                    .ThenInclude(customerUser => customerUser.User)
                .FirstOrDefaultAsync(shipInfo => shipInfo.Id == id);
            
            return entity ?? throw new EntityNotFoundException(nameof(ShipInfo), id);
        }
    }
}
