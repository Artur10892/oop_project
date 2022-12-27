using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Repositories.Abstract;
using Dapper;

namespace AdoDapperDAL.Repositories.Concrete
{
    public class PurchaseOrderProductRepository : GenericRepository<PurchaseOrderProduct>, IPurchaseOrderProductRepository
    {
        public PurchaseOrderProductRepository(IConnectionFactory connectionFactory):base(connectionFactory)
        {
        }
        
        public async Task<IEnumerable<object>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            const string sql = "SELECT Id, PurchaseOrderId, ProductId, OrderedQuantity " +
                                "FROM PurchaseOrderProducts " +
                                "WHERE PurchaseOrderId=@PurchaseOrderId";
            
            var values = new { PurchaseOrderId = purchaseOrderId};
            return await Connection.QueryAsync<object>(sql, values);
        }

        public async Task<int> InsertAsync(IEnumerable<PurchaseOrderProduct> products)
        {
            string sql = "";
            foreach (var product in products)
            {
                sql += "INSERT INTO PurchaseOrderProducts VALUES(" +
                       $"{product.PurchaseOrderId}, " +
                       $"{product.ProductId}, " +
                       $"{product.OrderedQuantity});";
            }

            return sql != "" ? await Connection.ExecuteAsync(sql) : 0;
        }
    }
}
