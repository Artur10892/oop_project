using AdoDapperDAL.Connection.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Exceptions;
using AdoDapperDAL.Repositories.Abstract;
using Dapper;

namespace AdoDapperDAL.Repositories.Concrete
{
    public class WarehouseProductRepository : GenericRepository<WarehouseProduct>, IWarehouseProductRepository
    {
        public WarehouseProductRepository(IConnectionFactory connectionFactory):base(connectionFactory)
        {
        }

        public async Task<IEnumerable<object>> GetByWarehouseIdAsync(int warehouseId)
        {
            const string? sql = "SELECT WarehouseProducts.Id AS 'Id', WarehouseId, " +
                                "Warehouses.Name AS 'WarehouseName', ProductId, " +
                                "WarehouseProducts.Quantity AS 'Quantity' " +
                                "FROM WarehouseProducts " +
                                "INNER JOIN Warehouses ON Warehouses.Id = WarehouseId " +
                                "WHERE WarehouseId=@WarehouseId";
            var values = new { WarehouseId = warehouseId};
            
            return await Connection.QueryAsync<object>(sql, values);
        }
        
        public async Task<object?> GetByWarehouseAndProductIdsAsync(int warehouseId, int productId)
        {
            const string? sql = "SELECT WarehouseProducts.Id AS 'Id', WarehouseId, " +
                                "Warehouses.Name AS 'WarehouseName', ProductId, " +
                                "WarehouseProducts.Quantity AS 'Quantity' " +
                                "FROM WarehouseProducts " +
                                "INNER JOIN Warehouses ON Warehouses.Id = WarehouseId " +
                                "WHERE WarehouseId=@WarehouseId AND ProductId=@ProductId";
            var values = new { WarehouseId = warehouseId, ProductId = productId};
            
            return await Connection.QueryFirstOrDefaultAsync<object?>(sql, values);
        }
        
        public async Task<int> InsertAsync(IEnumerable<WarehouseProduct> products)
        {
            string sql = "";
            foreach (var product in products)
            {
                sql += "INSERT INTO WarehouseProducts VALUES(" +
                       $"{product.WarehouseId}, " +
                       $"{product.ProductId}, " +
                       $"{product.Quantity});";
            }
            
            return sql != "" ? await Connection.ExecuteAsync(sql) : 0;
        }
        
        public async Task UpdateAsync(IEnumerable<WarehouseProduct> products)
        {
            string sql = "";
            foreach (var product in products)
            {
                sql += "UPDATE WarehouseProducts SET " +
                       $"WarehouseId = {product.WarehouseId}, " +
                       $"ProductId = {product.ProductId}, " +
                       $"Quantity = {product.Quantity} " +
                       $"WHERE Id = {product.Id};";
            }
            
            if (sql != "")
                await Connection.ExecuteAsync(sql);
        }
    }
}
