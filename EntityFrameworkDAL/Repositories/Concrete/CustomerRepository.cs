using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Repositories.Abstract;

namespace EntityFrameworkDAL.Repositories.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InventoryManagementDbContext dBContext) : base(dBContext)
        {
        }
    }
}
