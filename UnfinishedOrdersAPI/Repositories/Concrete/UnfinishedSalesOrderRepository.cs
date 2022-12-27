using Redis.OM;
using Redis.OM.Searching;
using UnfinishedOrdersAPI.Entities;
using UnfinishedOrdersAPI.Exceptions;
using UnfinishedOrdersAPI.Repositories.Abstract;

namespace UnfinishedOrdersAPI.Repositories.Concrete
{
    public class UnfinishedSalesOrderRepository : IUnfinishedSalesOrderRepository
    {
        private readonly RedisConnectionProvider _provider;
        private readonly RedisCollection<UnfinishedSalesOrder> _unfinishedSalesOrders;

        public UnfinishedSalesOrderRepository(RedisConnectionProvider provider)
        {
            _provider = provider;
            _unfinishedSalesOrders = (RedisCollection<UnfinishedSalesOrder>)
                provider.RedisCollection<UnfinishedSalesOrder>();
        }

        public async Task<IEnumerable<UnfinishedSalesOrder>> GetAllAsync()
        {
            return await _unfinishedSalesOrders.ToListAsync();
        }

        public async Task<UnfinishedSalesOrder> GetAsync(string orderId)
        {
            return await _unfinishedSalesOrders.FindByIdAsync(orderId) ??
                   throw new UnfinishedOrderNotFoundException(orderId);
        }

        public async Task<string> InsertAsync(UnfinishedSalesOrder unfinishedSalesOrder)
        {
            var insertedId = Guid.NewGuid();
            unfinishedSalesOrder.Id = insertedId;
            await _unfinishedSalesOrders.InsertAsync(unfinishedSalesOrder);
            return insertedId.ToString();
        }

        public async Task UpdateAsync(UnfinishedSalesOrder unfinishedSalesOrder)
        {
            await _unfinishedSalesOrders.UpdateAsync(unfinishedSalesOrder);
            await _unfinishedSalesOrders.SaveAsync();
        }

        public async Task DeleteByIdAsync(string orderId)
        {
            await _provider.Connection.UnlinkAsync($"UnfinishedSalesOrder:{orderId}");
        }
    }
}