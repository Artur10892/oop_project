using AutoMapper;
using Common.Events.OrderEvents;
using EntityFrameworkBLL.DTO.Requests;
using EntityFrameworkBLL.DTO.Responses;
using EntityFrameworkBLL.Protos;
using EntityFrameworkDAL.Entities;

namespace EntityFrameworkBLL.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateUserMaps()
        {
            CreateMap<UserRequest, User>();
            CreateMap<UserPostRequest, User>();
            
            CreateMap<User, UserResponse>();
        }
        
        private void CreateCustomerMaps()
        {
            CreateMap<CustomerRequest, Customer>();
            
            CreateMap<Customer, CustomerResponse>();
        }
        
        private void CreateSalesOrderMaps()
        {
            CreateMap<SalesOrderRequest, SalesOrder>();

            CreateMap<SalesOrder, SalesOrderResponse>()
                .ForMember(response => response.CustomerFullName,
                    options =>
                        options.MapFrom(salesOrder =>
                            salesOrder.ShipInfo.CustomerUser.User.FirstName + " " +
                            salesOrder.ShipInfo.CustomerUser.User.LastName)
                );


            CreateMap<FinishedSalesOrderEvent, SalesOrder>();
        }
        
        private void CreateShipInfoMaps()
        {
            CreateMap<ShipInfoRequest, ShipInfo>();
            CreateMap<ShipInfoPostRequest, ShipInfo>();

            CreateMap<ShipInfo, ShipInfoResponse>()
                .ForMember(response => response.CustomerFullName,
                    options =>
                        options.MapFrom(shipInfo =>
                            shipInfo.CustomerUser.User.FirstName + " " +
                            shipInfo.CustomerUser.User.LastName)
                );
        }

        private void CreateProductMaps()
        {
            CreateMap<SalesOrderProduct, SalesOrderProductResponse>();

            CreateMap<WarehouseProductResponse, UpdateWarehouseProductRequest>();
        }

        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateCustomerMaps();
            CreateSalesOrderMaps();
            CreateShipInfoMaps();
            CreateProductMaps();
        }
    }
}
