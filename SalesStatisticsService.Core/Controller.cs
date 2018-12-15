using System;
using System.Collections.Generic;
using System.Configuration;
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
            var fileNameSplitter = char.Parse(ConfigurationManager.AppSettings["fileNameSplitter"]);

            Task.Run(() =>
            {
                WriteToDatabase(
                    _parser.ParseFile(e.FullPath),
                    _parser.ParseLine(e.Name, fileNameSplitter).First());
            });
        }

        private void WriteToDatabase(IEnumerable<IFileContent> sales, string managerLastName)
        {
            using (_saleUnitOfWork)
            {
                _saleUnitOfWork.Add(CreateDataTransferObjects(sales, managerLastName).ToArray());
            }
        }

        private IEnumerable<SaleDto> CreateDataTransferObjects (IEnumerable<IFileContent> fileContents, string managerLastName)
        {
            var dateFormat = ConfigurationManager.AppSettings["dateFormat"];

            return (from fileContent in fileContents
                    let date = DateTime.ParseExact(fileContent.Date, dateFormat, null)
                    let customerName = _parser.ParseLine(fileContent.Customer, ' ')
                    let customerDto = new CustomerDto(customerName[0], customerName[1])
                    let productDto = new ProductDto(fileContent.Product)
                    let sum = decimal.Parse(fileContent.Sum)
                    let managerDto = new ManagerDto(managerLastName)
                    select new SaleDto(date, customerDto, productDto, sum, managerDto))
                .ToList();
        }
    }
}