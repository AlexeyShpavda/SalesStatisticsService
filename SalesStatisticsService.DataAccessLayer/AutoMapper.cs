using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer
{
    internal static class AutoMapper
    {
        internal static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(config => {
                config.CreateMap<Customer, ICustomer>();
                config.CreateMap<ICustomer, Customer>();

                config.CreateMap<Product, IProduct>();
                config.CreateMap<IProduct, Product>();

                config.CreateMap<Manager, IManager>();
                config.CreateMap<IManager, Manager>();

                config.CreateMap<Sale, ISale>();
                config.CreateMap<ISale, Sale>();
            });
        }
    }
}