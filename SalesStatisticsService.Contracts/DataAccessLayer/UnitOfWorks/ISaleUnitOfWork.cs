using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.Contracts.Entity;

namespace SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks
{
    public interface ISaleUnitOfWork : IDisposable
    {
        IGenericRepository<ICustomer, ICustomerEntity> Customers { get; }
        IGenericRepository<IManager, IManagerEntity> Managers { get; }
        IGenericRepository<IProduct, IProductEntity> Products { get; }
        IGenericRepository<ISale, ISaleEntity> Sales { get; }

        void Save();
    }
}