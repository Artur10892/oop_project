using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using ProductResponse = CleanArch_Application.DTO.Responses.ProductResponse;

namespace CleanArch_Application.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateCategoryMaps()
        {
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryPostRequest, Category>();
            
            CreateMap<Category, CategoryResponse>();
        }
        
        private void CreateLocationMaps()
        {
            CreateMap<LocationRequest, Location>();
            CreateMap<LocationPostRequest, Location>();

            CreateMap<Location, LocationResponse>()
                .ForMember(response => response.RegionName,
                    options =>
                        options.MapFrom(location => location.RegionNavigation.Name)
                );
        }
        
        private void CreateProductMaps()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<ProductPostRequest, Product>();

            CreateMap<Product, ProductResponse>()
                .ForMember(response => response.SupplierCompanyName,
                    options =>
                        options.MapFrom(product => product.Supplier.CompanyName)
                )
                .ForMember(response => response.CategoryName,
                    options =>
                        options.MapFrom(product => product.Category.Name)
                );
            
            CreateMap<Product, Protos.ProductResponse>()
                .ForMember(response => response.SupplierCompanyName,
                    options =>
                        options.MapFrom(product => product.Supplier.CompanyName)
                )
                .ForMember(response => response.CategoryName,
                    options =>
                        options.MapFrom(product => product.Category.Name)
                )
                .ForMember(response => response.Image,
                    options =>
                        options.MapFrom(product => product.Image ?? "")
                );;
        }
        
        private void CreateRegionMaps()
        {
            CreateMap<RegionRequest, Region>();
            CreateMap<RegionPostRequest, Region>();
            
            CreateMap<Region, RegionResponse>();
        }
        
        private void CreateSupplierMaps()
        {
            CreateMap<SupplierRequest, Supplier>();
            CreateMap<SupplierPostRequest, Supplier>();
            
            CreateMap<Supplier, SupplierResponse>()
                .ForMember(response => response.City,
                    options =>
                        options.MapFrom(supplier => supplier.Location.City)
                )
                .ForMember(response => response.LocalAddress,
                    options =>
                        options.MapFrom(supplier => supplier.Location.LocalAddress)
                )
                .ForMember(response => response.RegionName,
                    options =>
                        options.MapFrom(supplier => supplier.Location.RegionNavigation.Name)
                );
        }

        public AutoMapperProfile()
        {
            CreateCategoryMaps();
            CreateLocationMaps();
            CreateProductMaps();
            CreateRegionMaps();
            CreateSupplierMaps();
        }
    }
}
