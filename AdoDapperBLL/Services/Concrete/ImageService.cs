using System;
using System.IO;
using System.Threading.Tasks;
using AdoDapperBLL.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AdoDapperBLL.Services.Concrete
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;

        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(IFormFile? photo)
        {
            const string imagesFolderPath = "Public/Images/Products";

            if (!Directory.Exists($"{_environment.WebRootPath}/{imagesFolderPath}/"))
            {
                Directory.CreateDirectory($"{_environment.WebRootPath}/{imagesFolderPath}/");
            }

            var fileExtension = Path.GetExtension(photo?.FileName);
            string newFileName = $"{DateTime.Now:yyyyMMddHHmmssffff}{fileExtension}";
            await using var fileStream = File.Create($"{_environment.WebRootPath}/{imagesFolderPath}/{newFileName}");

            await photo?.CopyToAsync(fileStream)!;
            await fileStream.FlushAsync();

            return $"{imagesFolderPath}/{newFileName}";
        }
    }
}
