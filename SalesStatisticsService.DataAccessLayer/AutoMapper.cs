using System.Linq;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;
using SalesStatisticsService.Contracts.Entity;

namespace SalesStatisticsService.DataAccessLayer
{
    internal static class AutoMapper
    {
        internal static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config => {
                config.CreateMap<ICustomerEntity, CustomerDto>();
                config.CreateMap<CustomerDto, ICustomerEntity>();

                config.CreateMap<IProductEntity, ProductDto>();
                config.CreateMap<ProductDto, IProductEntity>();

                config.CreateMap<IManagerEntity, ManagerDto>();
                config.CreateMap<ManagerDto, IManagerEntity>();

                config.CreateMap<ISaleEntity, SaleDto>();
                config.CreateMap<SaleDto, ISaleEntity>();

                config.CreateMap<IQueryable<IEntity>, IQueryable<DataTransferObject>>();
            });
        }
    }
}