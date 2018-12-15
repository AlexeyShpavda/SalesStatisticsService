using System;
using System.Linq;
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

        private IGenericRepository<CustomerDto, Customer> Customers { get; }
        private IGenericRepository<ManagerDto, Manager> Managers { get; }
        private IGenericRepository<ProductDto, Product> Products { get; }
        private IGenericRepository<SaleDto, Sale> Sales { get; }

        public SaleUnitOfWork(SalesInformationContext context)
        {
            _context = context;

            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            Customers = new GenericRepository<CustomerDto, Customer>(_context, mapper);
            Managers = new GenericRepository<ManagerDto, Manager>(_context, mapper);
            Products = new GenericRepository<ProductDto, Product>(_context, mapper);
            Sales = new GenericRepository<SaleDto, Sale>(_context, mapper);
        }

        public void Add(params SaleDto[] sales)
        {
            lock (this)
            {
                foreach (var sale in sales)
                {
                    if (!_context.Customers.Any(x =>
                        x.LastName == sale.Customer.LastName && x.FirstName == sale.Customer.FirstName))
                    {
                        Customers.Add(sale.Customer);
                        Customers.Save();

                        sale.Customer.Id = Customers.Find(x =>
                            x.LastName == sale.Customer.LastName && x.FirstName == sale.Customer.FirstName).First().Id;

                    }
                    else
                    {
                        sale.Customer.Id = Customers.Find(x =>
                            x.LastName == sale.Customer.LastName && x.FirstName == sale.Customer.FirstName).First().Id;
                    }

                    if (!_context.Managers.Any(x => x.LastName == sale.Manager.LastName))
                    {
                        Managers.Add(sale.Manager);
                        Managers.Save();

                        sale.Manager.Id = Managers.Find(x => x.LastName == sale.Manager.LastName).First().Id;

                    }
                    else
                    {
                        sale.Manager.Id = Managers.Find(x => x.LastName == sale.Manager.LastName).First().Id;
                    }

                    if (!_context.Products.Any(x => x.Name == sale.Product.Name))
                    {
                        Products.Add(sale.Product);
                        Products.Save();

                        sale.Product.Id = Products.Find(x => x.Name == sale.Product.Name).First().Id;

                    }
                    else
                    {
                        sale.Product.Id = Products.Find(x => x.Name == sale.Product.Name).First().Id;
                    }

                    Sales.Add(sale);
                    Sales.Save();
                }
            }
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