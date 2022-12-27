using AdoDapperBLL.DTO.Requests;
using AdoDapperBLL.DTO.Responses;
using AdoDapperBLL.Protos;
using AdoDapperDAL.Entities;
using AutoMapper;
using WarehouseProductResponse = AdoDapperBLL.DTO.Responses.WarehouseProductResponse;
using WarehouseResponse = AdoDapperBLL.DTO.Responses.WarehouseResponse;

namespace AdoDapperBLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreatePurchaseOrderProductMaps()
        {
            CreateMap<ProductSubRequest, PurchaseOrderProduct>();
            
            CreateMap<PurchaseOrderProduct, PurchaseOrderProductResponse>();
        }
        
        private void CreatePurchaseOrderMaps()
        {
            CreateMap<PurchaseOrderPostRequest, PurchaseOrder>();
            
            CreateMap<PurchaseOrder, PurchaseOrderResponse>();
        }
        
        private void CreateWarehouseProductMaps()
        {
            CreateMap<ProductSubRequest, WarehouseProduct>();
            
            CreateMap<WarehouseProduct, WarehouseProductResponse>();

            CreateMap<WarehouseProduct, Protos.WarehouseProductResponse>();

            CreateMap<Protos.UpdateWarehouseProductRequest, WarehouseProduct>();
        }
        
        private void CreateWarehouseMaps()
        {
            CreateMap<WarehouseRequest, Warehouse>();
            
            CreateMap<Warehouse, WarehouseResponse>();
            
            CreateMap<Warehouse, Protos.WarehouseResponse>();
        }

        public AutoMapperProfile()
        {
            CreatePurchaseOrderProductMaps();
            CreatePurchaseOrderMaps();
            CreateWarehouseProductMaps();
            CreateWarehouseMaps();
        }
    }
}
