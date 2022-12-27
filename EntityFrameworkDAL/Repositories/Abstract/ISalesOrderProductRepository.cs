using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDAL.Repositories.Abstract
{
    public interface ISalesOrderProductRepository : IGenericRepository<SalesOrderProduct>
    {
        Task<IEnumerable<SalesOrderProduct>> GetBySalesOrderIdAsync(int salesOrderId);

        Task InsertRangeAsync(IEnumerable<SalesOrderProduct> products);
    }
}
