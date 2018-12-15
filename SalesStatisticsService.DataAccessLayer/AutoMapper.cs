using System.Linq;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Entity;

namespace SalesStatisticsService.DataAccessLayer
{
    internal static class AutoMapper
    {
        internal static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config => {
                config.CreateMap<ICustomerEntity, ICustomer>();
                config.CreateMap<ICustomer, ICustomerEntity>();

                config.CreateMap<IProductEntity, IProduct>();
                config.CreateMap<IProduct, IProductEntity>();

                config.CreateMap<IManagerEntity, IManager>();
                config.CreateMap<IManager, IManagerEntity>();

                config.CreateMap<ISaleEntity, ISale>();
                config.CreateMap<ISale, ISaleEntity>();

                config.CreateMap<IQueryable<IEntity>, IQueryable<IDataTransferObject>>();
            });
        }
    }
}