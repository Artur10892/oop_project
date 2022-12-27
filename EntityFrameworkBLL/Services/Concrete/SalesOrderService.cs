using AutoMapper;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;
using EntityFrameworkBLL.Protos;
using EntityFrameworkBLL.Services.Abstract;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Repositories.Abstract;
using EntityFrameworkDAL.UnitOfWork.Abstract;

namespace EntityFrameworkBLL.Services.Concrete
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ISalesOrderRepository _salesOrderRepository;

        private readonly ISalesOrderProductRepository _salesOrderProductRepository;

        private readonly Products.ProductsClient _productsClient;

        private readonly Warehouses.WarehousesClient _warehousesClient;

        public SalesOrderService(IUnitOfWork unitOfWork, IMapper mapper, Products.ProductsClient productsClient,
            Warehouses.WarehousesClient warehousesClient)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _salesOrderRepository = unitOfWork.SalesOrderRepository;
            _salesOrderProductRepository = unitOfWork.SalesOrderProductRepository;
            _productsClient = productsClient;
            _warehousesClient = warehousesClient;
        }

        private async Task<SalesOrderResponse> ExtendForResponse(SalesOrder salesOrder)
        {
            var response = _mapper.Map<SalesOrder, SalesOrderResponse>(salesOrder);
            var warehouse =
                await _warehousesClient.GetByIdAsync(new GetWarehouseByIdRequest {Id = salesOrder.WarehouseId});
            response.WarehouseName = warehouse.Name;
            return response;
        }

        public async Task<IEnumerable<SalesOrderResponse>> GetAllAsync()
        {
            var warehouses = await _salesOrderRepository.GetAllAsync();
            var responses = new List<SalesOrderResponse>();
            foreach (var warehouse in warehouses)
            {
                responses.Add(await ExtendForResponse(warehouse));
            }

            return responses;
        }

        public async Task<SalesOrderResponse> GetByIdAsync(int id)
        {
            var warehouse = await _salesOrderRepository.GetByIdAsync(id);
            return await ExtendForResponse(warehouse);
        }

        public async Task UpdateAsync(SalesOrderRequest request)
        {
            var entity = _mapper.Map<SalesOrderRequest, SalesOrder>(request);
            await _salesOrderRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _salesOrderRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrderProductResponse>> GetSalesOrderProducts(int purchaseOrderId)
        {
            await _salesOrderRepository.GetByIdAsync(purchaseOrderId);

            var salesOrderProducts =
                await _salesOrderProductRepository.GetBySalesOrderIdAsync(purchaseOrderId);
            var responses = new List<SalesOrderProductResponse>();
            foreach (var salesOrderProduct in salesOrderProducts)
            {
                var response = _mapper.Map<SalesOrderProduct, SalesOrderProductResponse>(salesOrderProduct);
                var product = await _productsClient.GetByIdAsync(new GetProductByIdRequest {Id = response.ProductId});
                response.ProductName = product.Name;
                responses.Add(response);
            }

            return responses;
        }
    }
}