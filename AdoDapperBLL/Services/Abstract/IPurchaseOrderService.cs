using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;

namespace AdoDapperBLL.Services.Abstract
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderResponse>> GetAllAsync();

        Task<PurchaseOrderResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(PurchaseOrderPostRequest postRequest);

        Task<bool> UpdateAsync(PurchaseOrderRequest postRequest);

        Task DeleteByIdAsync(int id);

        Task<IEnumerable<PurchaseOrderProductResponse>> GetPurchaseOrderProducts(int purchaseOrderId);
    }
}
