using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ICustomer> Customers { get; }
        IGenericRepository<IManager> Managers { get; }
        IGenericRepository<IProduct> Products { get; }
        IGenericRepository<ISale> Sales { get; }

        void Save();
    }
}