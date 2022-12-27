using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Repositories.Abstract;

namespace AdoDapperDAL.Repositories.Concrete
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(IConnectionFactory connectionFactory):base(connectionFactory)
        {
        }
    }
}
