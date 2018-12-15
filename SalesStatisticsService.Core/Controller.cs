using System;
using System.Collections.Generic;
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
            var fileNameSplitter = '_';
            Task.Run(() =>
            {
                WriteToDatabase(
                    _parser.ParseFile(e.FullPath),
                    _parser.ParseLine(e.Name, fileNameSplitter).First());
            });
        }

        private void WriteToDatabase(IEnumerable<IFileContent> sales, string managerLastName)
        {
            IList<SaleDto> saleDtos = new List<SaleDto>();
            using (_saleUnitOfWork)
            {
                foreach (var sale in sales)
                {
                    //_saleUnitOfWork.Add(saleDtos.Add(CreateDataTransferObjects<SaleDto>(sale, managerLastName)));
                    _saleUnitOfWork.Add(CreateDataTransferObjects(sale, managerLastName));
                }
            }
        }

        private SaleDto CreateDataTransferObjects (IFileContent sale, string managerLastName)
        {
            var date = DateTime.ParseExact(sale.Date, "dd.MM.yyyy", null);

            var customerName = _parser.ParseLine(sale.Customer, ' ');
            var customerDto = new CustomerDto(customerName[0], customerName[1]);

            var productDto = new ProductDto(sale.Product);

            var sum = decimal.Parse(sale.Sum);

            var managerDto = new ManagerDto(managerLastName);

            return new SaleDto(date, customerDto, productDto, sum, managerDto);
        }
    }
}