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
            foreach (var sale in sales)
            {
                //_saleUnitOfWork.Add(saleDtos.Add(CreateDataTransferObjects<SaleDto>(sale, managerLastName)));
                _saleUnitOfWork.Add(CreateDataTransferObjects<SaleDto>(sale, managerLastName));
            }
        }

        private SaleDto CreateDataTransferObjects<T> (IFileContent sale, string managerName)
        {
            IList<string> name = _parser.ParseLine(sale.Customer, ' ');
            CustomerDto customerDto = new CustomerDto();
            customerDto.LastName = name[0];
            customerDto.FirstName = name[1];



            ManagerDto managerDto = new ManagerDto();
            managerDto.LastName = managerName;

            ProductDto product = new ProductDto();
            product.Name = sale.Product;


            string timeString = sale.Date.Replace('.', '/');
            DateTime dateTime = DateTime.ParseExact(timeString, "dd/MM/yyyy", null);

            //DateTime dateTime = System.DateTime.Parse(timeString);
            //dateTime.ToString("dd/mm/yyyy");

            //dateTime.Date = timeString;
            //DateTime dateTime = DateTime.Parse(timeString);

            decimal sum = decimal.Parse(sale.Sum);

            SaleDto saleDto = new SaleDto();

            saleDto.Manager = managerDto;
            saleDto.Product = product;
            saleDto.Customer = customerDto;
            saleDto.Date = dateTime;
            saleDto.Sum = sum;


            return saleDto;
            //managerDto.LastName =
        }
    }
}