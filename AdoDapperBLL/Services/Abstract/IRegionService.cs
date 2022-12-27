using System.Collections.Generic;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;

namespace AdoDapperBLL.Services.Abstract
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionResponse>> GetAllAsync();

        Task<RegionResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(RegionRequest request);

        Task<bool> UpdateAsync(RegionRequest request);

        Task DeleteByIdAsync(int id);
    }
}
