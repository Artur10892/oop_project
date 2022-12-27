using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;

namespace EntityFrameworkBLL.Services.Abstract
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderResponse>> GetAllAsync();

        Task<SalesOrderResponse> GetByIdAsync(int id);

        Task UpdateAsync(SalesOrderRequest request);

        Task DeleteByIdAsync(int id);

        Task<IEnumerable<SalesOrderProductResponse>> GetSalesOrderProducts(int purchaseOrderId);
    }
}
