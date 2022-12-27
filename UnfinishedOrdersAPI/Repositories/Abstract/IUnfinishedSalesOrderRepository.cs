using UnfinishedOrdersAPI.Entities;

namespace UnfinishedOrdersAPI.Repositories.Abstract
{
    public interface IUnfinishedSalesOrderRepository
    {
        Task<IEnumerable<UnfinishedSalesOrder>> GetAllAsync();

        Task<UnfinishedSalesOrder> GetAsync(string orderId);

        Task<string> InsertAsync(UnfinishedSalesOrder unfinishedSalesOrder);
        
        Task UpdateAsync(UnfinishedSalesOrder unfinishedSalesOrder);

        Task DeleteByIdAsync(string orderId);
    }
}
