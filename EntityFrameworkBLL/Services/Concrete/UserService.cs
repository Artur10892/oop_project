using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;
using EntityFrameworkBLL.Services.Abstract;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Repositories.Abstract;
using EntityFrameworkDAL.UnitOfWork.Abstract;

namespace EntityFrameworkBLL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IMapper _mapper;
        
        private readonly IUserRepository _userRepository;

        private readonly IImageService _imageService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
            _userRepository = unitOfWork.UserRepository;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var result = await _userRepository.GetAllAsync();
            return result.Select(_mapper.Map<User, UserResponse>);
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<User, UserResponse>(result);
        }

        public async Task<int> InsertAsync(UserPostRequest request)
        {
            var entity = _mapper.Map<UserPostRequest, User>(request);
            await _userRepository.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(UserRequest request)
        {
            var entity = _mapper.Map<UserRequest, User>(request);
            await _userRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _userRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task SetAvatarForUserAsync(ImageUploadRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            user.Avatar = await _imageService.SaveImageAsync(request.Image);
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
