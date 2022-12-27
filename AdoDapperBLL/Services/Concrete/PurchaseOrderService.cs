using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;
using AdoDapperBLL.Protos;
using AdoDapperBLL.Services.Abstract;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Repositories.Abstract;
using AdoDapperDAL.UnitOfWork.Abstract;
using AutoMapper;

namespace AdoDapperBLL.Services.Concrete
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IMapper _mapper;

        private readonly IWarehouseService _warehouseService;

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        private readonly IPurchaseOrderProductRepository _purchaseOrderProductRepository;

        private readonly Products.ProductsClient _productsClient;

        public PurchaseOrderService(IUnitOfWork unitOfWork, IMapper mapper, IWarehouseService warehouseService, Products.ProductsClient productsClient)
        {
            _mapper = mapper;
            _warehouseService = warehouseService;
            _purchaseOrderRepository = unitOfWork.PurchaseOrderRepository;
            _purchaseOrderProductRepository = unitOfWork.PurchaseOrderProductRepository;
            _productsClient = productsClient;
        }

        public async Task<IEnumerable<PurchaseOrderResponse>> GetAllAsync()
        {
            var result = await _purchaseOrderRepository.GetAllAsync();
            return result.Select(_mapper.Map<PurchaseOrder, PurchaseOrderResponse>);
        }

        public async Task<PurchaseOrderResponse> GetByIdAsync(int id)
        {
            var result = await _purchaseOrderRepository.GetByIdAsync(id);
            return _mapper.Map<PurchaseOrder, PurchaseOrderResponse>(result);
        }

        public async Task<int> InsertAsync(PurchaseOrderPostRequest request)
        {
            var entity = _mapper.Map<PurchaseOrderPostRequest, PurchaseOrder>(request);
            entity.OrderStatusCode = 1;
            entity.TotalPrice = await CountProductsTotalPrice(request.products);
            var insertedId = await _purchaseOrderRepository.InsertAsync(entity);
            await AddPurchaseOrderProducts(insertedId, request.products);
            await _warehouseService.AddToWarehouseProducts(entity.WarehouseId, request.products);
            return insertedId;
        }

        public async Task<bool> UpdateAsync(PurchaseOrderRequest request)
        {
            var entity = _mapper.Map<PurchaseOrderRequest, PurchaseOrder>(request);
            var result = await _purchaseOrderRepository.UpdateAsync(entity);
            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _purchaseOrderRepository.DeleteByIdAsync(id);
        }
        
        public async Task<IEnumerable<PurchaseOrderProductResponse>> GetPurchaseOrderProducts(int purchaseOrderId)
        {
            await _purchaseOrderRepository.GetByIdAsync(purchaseOrderId);
            
            var purchaseOrderProducts = 
                await _purchaseOrderProductRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
            var requests = new List<PurchaseOrderProductResponse>();
            foreach (var purchaseOrderProduct in purchaseOrderProducts)
            {
                var response = _mapper.Map<object, PurchaseOrderProductResponse>(purchaseOrderProduct);
                var product = await _productsClient.GetByIdAsync(new GetProductByIdRequest{Id = response.ProductId});
                response.ProductName = product.Name;
                requests.Add(response);
            }

            return requests;
        }

        private async Task AddPurchaseOrderProducts(int purchaseOrderId, IEnumerable<ProductSubRequest> productRequests)
        {
            var productsToInsert = new List<PurchaseOrderProduct>();
            foreach (var productRequest in productRequests)
            {
                var product = _mapper.Map<ProductSubRequest, PurchaseOrderProduct>(productRequest);
                product.PurchaseOrderId = purchaseOrderId;
                productsToInsert.Add(product);
            }
            await _purchaseOrderProductRepository.InsertAsync(productsToInsert);
        }

        private async Task<decimal> CountProductsTotalPrice(IEnumerable<ProductSubRequest> productRequests)
        {
            double totalPrice = 0;
            foreach (var productRequest in productRequests)
            {
                var product = await _productsClient.GetByIdAsync(new GetProductByIdRequest{Id = productRequest.ProductId});
                totalPrice += product.PurchasePrice * productRequest.OrderedQuantity;
            }

            return Convert.ToDecimal(totalPrice);
        }
    }
}
