using AdoDapperBLL.Protos;
using AdoDapperDAL.Entities;
using AdoDapperDAL.Exceptions;
using AdoDapperDAL.Repositories.Abstract;
using AutoMapper;
using Grpc.Core;

namespace AdoDapperBLL.Grpc;

public class WarehousesService : Warehouses.WarehousesBase
{
    private readonly IMapper _mapper;

    private readonly IWarehouseRepository _warehouseRepository;

    private readonly IWarehouseProductRepository _warehouseProductRepository;

    public WarehousesService(IMapper mapper, IWarehouseRepository warehouseRepository,
        IWarehouseProductRepository warehouseProductRepository)
    {
        _mapper = mapper;
        _warehouseRepository = warehouseRepository;
        _warehouseProductRepository = warehouseProductRepository;
    }

    public override async Task<WarehousesResponse> GetAll(GetAllWarehousesRequest request, ServerCallContext context)
    {
        var warehousesResponse = new WarehousesResponse();
        var warehouses = await _warehouseRepository.GetAllAsync();

        var mappedResults =
            warehouses.Select(result => _mapper.Map<Warehouse, WarehouseResponse>(result)).ToList();

        warehousesResponse.Data.AddRange(mappedResults);
        return warehousesResponse;
    }

    public override async Task<WarehouseResponse> GetById(GetWarehouseByIdRequest request, ServerCallContext context)
    {
        var warehouse = await _warehouseRepository.GetByIdAsync(request.Id);
        return _mapper.Map<Warehouse, WarehouseResponse>(warehouse);
    }

    public override async Task<WarehouseProductResponse?> GetByProductAndWarehouseId(
        GetByProductAndWarehouseIdRequest request, ServerCallContext context)
    {
        var warehouseProduct =
            await _warehouseProductRepository.GetByWarehouseAndProductIdsAsync(request.WarehouseId, request.ProductId);
        if (warehouseProduct == null)
            return null;
        return _mapper.Map<WarehouseProductResponse>(warehouseProduct);
    }

    public override async Task<UpdateWarehouseProductsResponse> UpdateWarehouseProducts(
        UpdateWarehouseProductsRequest request, ServerCallContext context)
    {
        try
        {
            var products = request.Data.Select(_mapper.Map<UpdateWarehouseProductRequest, WarehouseProduct>);
            await _warehouseProductRepository.UpdateAsync(products);
            return new UpdateWarehouseProductsResponse {Success = true};
        }
        catch (Exception e)
        {
            return new UpdateWarehouseProductsResponse {Success = false};
        }
    }
}