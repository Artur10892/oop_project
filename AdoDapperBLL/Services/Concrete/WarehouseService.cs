using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.Protos;
using AdoDapperBLL.Services.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Repositories.Abstract;
using AdoDapperDAL.UnitOfWork.Abstract;
using AutoMapper;
using WarehouseProductResponse = AdoDapperBLL.DTO.Responses.WarehouseProductResponse;
using WarehouseResponse = AdoDapperBLL.DTO.Responses.WarehouseResponse;

namespace AdoDapperBLL.Services.Concrete
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;

        private readonly IWarehouseRepository _warehouseRepository;

        private readonly IWarehouseProductRepository _warehouseProductRepository;

        private readonly Products.ProductsClient _productsClient;

        public WarehouseService(IUnitOfWork unitOfWork, IMapper mapper, Products.ProductsClient productsClient)
        {
            _mapper = mapper;
            _warehouseRepository = unitOfWork.WarehouseRepository;
            _warehouseProductRepository = unitOfWork.WarehouseProductRepository;
            _productsClient = productsClient;
        }

        public async Task<IEnumerable<WarehouseResponse>> GetAllAsync()
        {
            var result = await _warehouseRepository.GetAllAsync();
            return result.Select(_mapper.Map<Warehouse, WarehouseResponse>);
        }

        public async Task<WarehouseResponse> GetByIdAsync(int id)
        {
            var result = await _warehouseRepository.GetByIdAsync(id);
            return _mapper.Map<Warehouse, WarehouseResponse>(result);
        }

        public async Task<int> InsertAsync(WarehouseRequest request)
        {
            var entity = _mapper.Map<WarehouseRequest, Warehouse>(request);
            var insertedId = await _warehouseRepository.InsertAsync(entity);
            return insertedId;
        }

        public async Task<bool> UpdateAsync(WarehouseRequest request)
        {
            var entity = _mapper.Map<WarehouseRequest, Warehouse>(request);
            var result = await _warehouseRepository.UpdateAsync(entity);
            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _warehouseRepository.DeleteByIdAsync(id);
        }

        private async Task<WarehouseProductResponse> ExtendForResponse(object warehouseProduct)
        {
            var response = _mapper.Map<object, WarehouseProductResponse>(warehouseProduct);
            //throw new NotImplementedException("Implement product using gRPC");
             var product = await _productsClient.GetByIdAsync(new GetProductByIdRequest{Id = response.ProductId});
            response.ProductName = product.Name;
            return response;
        }

        public async Task<IEnumerable<WarehouseProductResponse>> GetWarehouseProducts(int warehouseId)
        {
            await _warehouseRepository.GetByIdAsync(warehouseId);

            var warehouseProducts = await _warehouseProductRepository.GetByWarehouseIdAsync(warehouseId);
            var responses = new List<WarehouseProductResponse>();
            foreach (var warehouseProduct in warehouseProducts)
            {
                var request = await ExtendForResponse(warehouseProduct);
                responses.Add(request);
            }

            return responses;
        }

        public async Task<WarehouseProductResponse?> GetWarehouseProductById(int warehouseId, int productId)
        {
            await _warehouseRepository.GetByIdAsync(warehouseId);

            var warehouseProduct =
                await _warehouseProductRepository.GetByWarehouseAndProductIdsAsync(warehouseId, productId);
            return warehouseProduct==null ? null : await ExtendForResponse(warehouseProduct);
        }

        public async Task AddToWarehouseProducts(int warehouseId, IEnumerable<ProductSubRequest> productRequests)
        {
            var productsToInsert = new List<WarehouseProduct>();
            var productsToUpdate = new List<WarehouseProduct>();
            foreach (var productRequest in productRequests)
            {
                var newWarehouseProduct = _mapper.Map<ProductSubRequest, WarehouseProduct>(productRequest);
                newWarehouseProduct.WarehouseId = warehouseId;
                var warehouseProduct =
                    await GetWarehouseProductById(warehouseId, newWarehouseProduct.ProductId);
                if (warehouseProduct == null)
                {
                    newWarehouseProduct.Quantity = productRequest.OrderedQuantity;
                    productsToInsert.Add(newWarehouseProduct);
                }
                else
                {
                    newWarehouseProduct.Quantity = warehouseProduct.Quantity + productRequest.OrderedQuantity;
                    newWarehouseProduct.Id = warehouseProduct.Id;
                    productsToUpdate.Add(newWarehouseProduct);
                }
            }

            await _warehouseProductRepository.InsertAsync(productsToInsert);
            await _warehouseProductRepository.UpdateAsync(productsToUpdate);
        }
    }
}