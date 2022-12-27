using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Repositories.Abstract;

namespace EntityFrameworkDAL.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InventoryManagementDbContext dBContext) : base(dBContext)
        {
        }
    }
}
