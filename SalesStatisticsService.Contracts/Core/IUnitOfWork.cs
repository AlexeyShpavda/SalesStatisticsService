using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer;
using SalesStatisticsService.Contracts.Entity;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ICustomer, ICustomerEntity> Customers { get; }
        IGenericRepository<IManager, IManagerEntity> Managers { get; }
        IGenericRepository<IProduct, IProductEntity> Products { get; }
        IGenericRepository<ISale, ISaleEntity> Sales { get; }

        void Save();
    }
}