using AutoMapper;
using Common.Events.OrderEvents;
using UnfinishedOrdersAPI.Entities;

namespace UnfinishedOrdersAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateSalesOrdersMaps();
        }

        private void CreateSalesOrdersMaps()
        {
            CreateMap<UnfinishedSalesOrder, FinishedSalesOrderEvent>();
        }
    }
}