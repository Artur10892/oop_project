using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperDAL.Entities;

namespace AdoDapperDAL.Repositories.Abstract
{
    public interface IPurchaseOrderProductRepository : IGenericRepository<PurchaseOrderProduct>
    {
        Task<IEnumerable<object>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        Task<int> InsertAsync(IEnumerable<PurchaseOrderProduct> products);
    }
}
