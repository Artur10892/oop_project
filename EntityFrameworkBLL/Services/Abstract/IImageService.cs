using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EntityFrameworkBLL.Services.Abstract
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile? photo);
    }
}
