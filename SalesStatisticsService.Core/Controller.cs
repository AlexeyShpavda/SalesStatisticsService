using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.Core.DirectoryWatchers;
using SalesStatisticsService.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.Entity;
using IParser = SalesStatisticsService.Contracts.Core.IParser;

namespace SalesStatisticsService.Core
{
    public class Controller : IController
    {
        private readonly IDirectoryWatcher _directoryWatcher;
        private readonly ISaleUnitOfWork _saleUnitOfWork;
        private readonly IParser _parser;

        public Controller()
        {
            _directoryWatcher = new DirectoryWatcher();

            _saleUnitOfWork = new SaleUnitOfWork(new SalesInformationContext());

            _parser = new Parser();
        }

        public void Run()
        {
            _directoryWatcher.Run(this);
        }

        public void Stop()
        {
            _directoryWatcher.Stop(this);
        }

        public void ProcessFile(object source, FileSystemEventArgs e)
        {
            //var task = Task<IEnumerable<IFileContent>>.Factory.StartNew(() =>
            //{
            //    WriteToDatabase(_parser.ParseFile(e.FullPath));
            //});
            var fileNameSplitter = '_';
            Task.Run(() =>
                {
                    WriteToDatabase(
                        _parser.ParseFile(e.FullPath),
                        _parser.ParseLine(e.Name, fileNameSplitter).First());
                });
            //task.ContinueWith((t, o) => WriteToDatabase(t.Result), null,
            //   TaskScheduler.FromCurrentSynchronizationContext());

            //task.ContinueWith((t, o) => WriteToDatabase(t.Result), null,
            //   TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void WriteToDatabase(IEnumerable<IFileContent> sales, string managerLastName)
        {
            IList<SaleDto> saleDtos = new List<SaleDto>();
            using (_saleUnitOfWork)
            {
                foreach (var sale in sales)
                {
                    //_saleUnitOfWork.Add(saleDtos.Add(CreateDataTransferObjects<SaleDto>(sale, managerLastName)));
                    _saleUnitOfWork.Add(CreateDataTransferObjects<SaleDto>(sale, managerLastName));
                }
            }
        }

        private SaleDto CreateDataTransferObjects<T> (IFileContent sale, string managerName)
        {
            var name = _parser.ParseLine(sale.Customer, ' ');
            var customerDto = new CustomerDto
            {
                FirstName = name[0],
                LastName = name[1]
            };

            var managerDto = new ManagerDto
            {
                LastName = managerName
            };

            var productDto = new ProductDto
            {
                Name = sale.Product
            };

            var timeString = sale.Date.Replace('.', '/');
            var dateTime = DateTime.ParseExact(timeString, "dd/MM/yyyy", null);

            var sum = decimal.Parse(sale.Sum);

            var saleDto = new SaleDto
            {
                Manager = managerDto,
                Product = productDto,
                Customer = customerDto,
                Date = dateTime,
                Sum = sum
            };

            return saleDto;
        }
    }
}