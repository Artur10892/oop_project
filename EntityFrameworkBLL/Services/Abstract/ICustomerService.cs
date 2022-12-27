using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;

namespace EntityFrameworkBLL.Services.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllAsync();

        Task<CustomerResponse> GetByIdAsync(int id);

        Task InsertAsync(CustomerRequest request);

        Task UpdateAsync(CustomerRequest request);

        Task DeleteByIdAsync(int id);
    }
}
