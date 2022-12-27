using AutoMapper;
using Common.Events.OrderEvents;
using EntityFrameworkBLL.Exceptions;
using EntityFrameworkBLL.Protos;
using EntityFrameworkDAL.Entities;
using EntityFrameworkDAL.Exceptions;
using EntityFrameworkDAL.Repositories.Abstract;
using EntityFrameworkDAL.UnitOfWork.Abstract;
using MassTransit;

namespace EntityFrameworkBLL.EventBusConsumers.OrderConsumers;

public class FinishedSalesOrderConsumer : IConsumer<FinishedSalesOrderEvent>
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    private readonly ISalesOrderRepository _salesOrderRepository;

    private readonly ISalesOrderProductRepository _salesOrderProductRepository;

    private readonly Products.ProductsClient _productsClient;

    private readonly Warehouses.WarehousesClient _warehousesClient;

    public FinishedSalesOrderConsumer(IMapper mapper, IUnitOfWork unitOfWork, Products.ProductsClient productsClient,
        Warehouses.WarehousesClient warehousesClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productsClient = productsClient;
        _warehousesClient = warehousesClient;
        _salesOrderRepository = unitOfWork.SalesOrderRepository;
        _salesOrderProductRepository = unitOfWork.SalesOrderProductRepository;
    }

    public async Task Consume(ConsumeContext<FinishedSalesOrderEvent> context)
    {
        var salesOrder = _mapper.Map<SalesOrder>(context.Message);
        
        var productsToUpdate = new List<UpdateWarehouseProductRequest>();
        double orderTotalPrice = 0;
        await using var transaction = await _unitOfWork.DbContext.Database.BeginTransactionAsync();

        try
        {
            for (var index = 0; index < context.Message.ProductIds.Length; index++)
            {
                var productId = context.Message.ProductIds[index];
                var productQuantity = context.Message.ProductQuantities[index];
                var warehouseProductResponse =
                    await _warehousesClient.GetByProductAndWarehouseIdAsync(new GetByProductAndWarehouseIdRequest
                        {WarehouseId = context.Message.WarehouseId, ProductId = productId});
                if (warehouseProductResponse == null)
                    throw new Exception("Warehouse product not found!");

                if (productQuantity > warehouseProductResponse.Quantity)
                    throw new QuantityExceededException();

                var product = await _productsClient.GetByIdAsync(new GetProductByIdRequest {Id = productId});
                orderTotalPrice += productQuantity * product.SellPrice;

                // reducing warehouse product quantity
                var updatedWarehouseProduct = _mapper.Map<UpdateWarehouseProductRequest>(warehouseProductResponse);
                updatedWarehouseProduct.Quantity = warehouseProductResponse.Quantity - productQuantity;
                productsToUpdate.Add(updatedWarehouseProduct);
            }

            salesOrder.TotalPrice = (decimal) orderTotalPrice;
            salesOrder.OrderStatusCode = 1;
            await _salesOrderRepository.InsertAsync(salesOrder);
            await _unitOfWork.SaveChangesAsync();

            var insertedId = salesOrder.Id;
            var salesOrderProducts = context.Message.ProductIds
                .Select(productId =>
                    new SalesOrderProduct {SalesOrderId = insertedId, ProductId = productId}
                ).ToList();
            await _salesOrderProductRepository.InsertRangeAsync(salesOrderProducts);
            await _unitOfWork.SaveChangesAsync();

            var insertRequest = new UpdateWarehouseProductsRequest();
            insertRequest.Data.AddRange(productsToUpdate);
            var result = await _warehousesClient.UpdateWarehouseProductsAsync(insertRequest);
            if (result == null || !result.Success)
                throw new Exception("Warehouse products can not be inserted. Warehouse gRPC problem");
            
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}