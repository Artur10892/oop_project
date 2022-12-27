using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;
using AdoDapperDAL.Entities;

namespace AdoDapperBLL.Services.Abstract
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseResponse>> GetAllAsync();

        Task<WarehouseResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(WarehouseRequest request);

        Task<bool> UpdateAsync(WarehouseRequest request);

        Task DeleteByIdAsync(int id);

        Task<IEnumerable<WarehouseProductResponse>> GetWarehouseProducts(int warehouseId);

        Task<WarehouseProductResponse?> GetWarehouseProductById(int warehouseId, int productId);

        Task AddToWarehouseProducts(int warehouseId, IEnumerable<ProductSubRequest> productRequests);
    }
}
