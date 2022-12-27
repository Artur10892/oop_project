using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AdoDapperBLL.Services.Abstract
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile? photo);
    }
}
