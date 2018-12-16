using System.Linq;
using System.Threading;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.DataAccessLayer.Repositories;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.UnitOfWorks
{
    public class SaleUnitOfWork : ISaleUnitOfWork
    {
        private SalesInformationContext Context { get; }
        private ReaderWriterLockSlim Locker { get; }

        private ICustomerRepository Customers { get; }
        private IManagerRepository Managers { get; }
        private IProductRepository Products { get; }
        private ISaleRepository Sales { get; }

        public SaleUnitOfWork(SalesInformationContext context, ReaderWriterLockSlim locker)
        {
            Context = context;
            Locker = locker;

            var mapper = AutoMapper.CreateConfiguration().CreateMapper();
            Customers = new CustomerRepository(Context, mapper);
            Managers = new ManagerRepository(Context, mapper);
            Products = new ProductRepository(Context, mapper);
            Sales = new SaleRepository(Context, mapper);
        }

        public void Add(params SaleDto[] sales)
        {
            Locker.EnterWriteLock();
            try
            {
                foreach (var sale in sales)
                {
                    Customers.AddUniqueCustomerToDatabase(sale.Customer);
                    Customers.Save();
                    sale.Customer.Id = Customers.Find(x =>
                        x.LastName == sale.Customer.LastName && x.FirstName == sale.Customer.FirstName).First().Id;

                    Managers.AddUniqueManagerToDatabase(sale.Manager);
                    Managers.Save();
                    sale.Manager.Id = Managers.Find(x => x.LastName == sale.Manager.LastName).First().Id;

                    Products.AddUniqueProductToDatabase(sale.Product);
                    Products.Save();
                    sale.Product.Id = Products.Find(x => x.Name == sale.Product.Name).First().Id;

                    Sales.Add(sale);
                    Sales.Save();
                }
            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }
    }
}