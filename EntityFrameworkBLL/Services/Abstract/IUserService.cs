using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;

namespace EntityFrameworkBLL.Services.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();

        Task<UserResponse> GetByIdAsync(int id);

        Task<int> InsertAsync(UserPostRequest postRequest);

        Task UpdateAsync(UserRequest request);

        Task DeleteByIdAsync(int id);

        Task SetAvatarForUserAsync(ImageUploadRequest request);
    }
}
