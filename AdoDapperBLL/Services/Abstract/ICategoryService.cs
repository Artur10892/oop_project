using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;

namespace AdoDapperBLL.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllAsync();

        Task<CategoryResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(CategoryRequest request);

        Task<bool> UpdateAsync(CategoryRequest request);

        Task DeleteByIdAsync(int id);
    }
}
