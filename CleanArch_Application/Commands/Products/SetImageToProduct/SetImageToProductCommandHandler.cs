using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Products.SetImageToProduct
{
    public class SetImageToProductCommandHandler: IRequestHandler<SetImageToProductCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Product> _table;
        
        private readonly IWebHostEnvironment _environment;

        public SetImageToProductCommandHandler(DbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Product>();
            _environment = environment;
        }
        
        public async Task<Unit> Handle(SetImageToProductCommand request, CancellationToken cancellationToken)
        {
            var uploadRequest = request.ImageUploadRequest;
            var foundEntity = await _table
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == uploadRequest.Id, cancellationToken);
            if(foundEntity == null)
                throw new EntityNotFoundException(nameof(Product), uploadRequest.Id);

            foundEntity.Image = await SaveImageAsync(uploadRequest.Image);
            await Task.Run(() => _table.Update(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<string> SaveImageAsync(IFormFile? photo)
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