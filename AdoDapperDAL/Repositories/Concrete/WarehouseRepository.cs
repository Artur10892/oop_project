using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Repositories.Abstract;

namespace AdoDapperDAL.Repositories.Concrete
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IConnectionFactory connectionFactory):base(connectionFactory)
        {
        }
    }
}
