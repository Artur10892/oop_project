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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IMapper _mapper;
        
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _customerRepository = unitOfWork.CustomerRepository;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            return result.Select(_mapper.Map<Customer, CustomerResponse>);
        }

        public async Task<CustomerResponse> GetByIdAsync(int id)
        {
            var result = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<Customer, CustomerResponse>(result);
        }

        public async Task InsertAsync(CustomerRequest request)
        {
            var entity = _mapper.Map<CustomerRequest, Customer>(request);
            await _customerRepository.InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerRequest request)
        {
            var entity = _mapper.Map<CustomerRequest, Customer>(request);
            await _customerRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _customerRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
