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

        private IGenericRepository<CustomerDto, ICustomerEntity> Customers { get; }
        private IGenericRepository<ManagerDto, IManagerEntity> Managers { get; }
        private IGenericRepository<ProductDto, IProductEntity> Products { get; }
        private IGenericRepository<SaleDto, ISaleEntity> Sales { get; }

        public SaleUnitOfWork(SalesInformationContext context)
        {
            _context = context;

            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            Customers = new GenericRepository<CustomerDto, ICustomerEntity>(_context, mapper);
            Managers = new GenericRepository<ManagerDto, IManagerEntity>(_context, mapper);
            Products = new GenericRepository<ProductDto, IProductEntity>(_context, mapper);
            Sales = new GenericRepository<SaleDto, ISaleEntity>(_context, mapper);
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
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