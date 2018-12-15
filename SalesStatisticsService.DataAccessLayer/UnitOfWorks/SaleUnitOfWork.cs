using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.Contracts.Entity;
using SalesStatisticsService.DataAccessLayer.Repositories;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.UnitOfWorks
{
    public class SaleUnitOfWork : ISaleUnitOfWork
    {
        private readonly SalesInformationContext _context;

        public IGenericRepository<ICustomer, ICustomerEntity> Customers { get; }
        public IGenericRepository<IManager, IManagerEntity> Managers { get; }
        public IGenericRepository<IProduct, IProductEntity> Products { get; }
        public IGenericRepository<ISale, ISaleEntity> Sales { get; }

        public SaleUnitOfWork(SalesInformationContext context)
        {
            _context = context;

            Customers = new GenericRepository<ICustomer, ICustomerEntity>(_context);
            Managers = new GenericRepository<IManager, IManagerEntity>(_context);
            Products = new GenericRepository<IProduct, IProductEntity>(_context);
            Sales = new GenericRepository<ISale, ISaleEntity>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Customers.Dispose();
                    Managers.Dispose();
                    Products.Dispose();
                    Sales.Dispose();
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}