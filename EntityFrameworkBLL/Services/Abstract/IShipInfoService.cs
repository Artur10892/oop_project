using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;

namespace EntityFrameworkBLL.Services.Abstract
{
    public interface IShipInfoService
    {
        Task<IEnumerable<ShipInfoResponse>> GetAllAsync();

        Task<ShipInfoResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(ShipInfoPostRequest postRequest);

        Task UpdateAsync(ShipInfoRequest request);

        Task DeleteByIdAsync(int id);
    }
}
