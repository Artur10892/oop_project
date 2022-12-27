using Microsoft.AspNetCore.Http;

namespace CleanArch_Application.DTO.Requests
{
    public class ImageUploadRequest
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; } = null!;
    }
}
