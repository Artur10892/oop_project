using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;

namespace AdoDapperBLL.Services.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllAsync();

        Task<ProductResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(ProductRequest request);

        Task<bool> UpdateAsync(ProductRequest request);

        Task DeleteByIdAsync(int id);

        Task SetImageAsync(ImageUploadRequest request);
    }
}
