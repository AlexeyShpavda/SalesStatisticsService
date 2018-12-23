using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks;
using IParser = SalesStatisticsService.Contracts.Core.IParser;

namespace SalesStatisticsService.Core.FileProcessing
{
    public class FileHandler
    {
        private ReaderWriterLockSlim Locker { get; }

        private ISaleUnitOfWork SaleUnitOfWork { get; }
        private IParser Parser { get; }
        private ILogger Logger { get; }

        public FileHandler(ISaleUnitOfWork saleUnitOfWork, IParser parser, ILogger logger, ReaderWriterLockSlim locker)
        {
            SaleUnitOfWork = saleUnitOfWork;
            Parser = parser;
            Logger = logger;
            Locker = locker;
        }

        public void ProcessFile(object source, FileSystemEventArgs e)
        {
            Logger.WriteLine($"{e.Name} Has Been Added to Directory.");
            var fileNameSplitter = char.Parse(ConfigurationManager.AppSettings["fileNameSplitter"]);

            Task.Run(() =>
            {
                try
                {
                    WriteToDatabase(
                        Parser.ParseFile(e.FullPath),
                        Parser.ParseLine(e.Name, fileNameSplitter).First());

                    Log($"{e.Name} Was Successfully Added to Database");
                }
                catch (HeaderValidationException)
                {
                    Log($"{e.Name} First Line Must Match Template =>" +
                        " Date | Customer | Product | Sum");
                }
                catch (FormatException exception)
                {
                    Log($"{e.Name} {exception.Message}");
                }
                catch (ArgumentNullException)
                {
                    Log("AppConfig Must Contain Format of Date Entry" +
                        " and Separator of First and Last Customer Name");
                }
                catch (Exception)
                {
                    Log($"{e.Name} AN ERROR OCCURRED, Information is not Added to Database");
                }
            });
        }

        private void Log(string message)
        {
            Locker.EnterWriteLock();
            try
            {
                Logger.WriteLine(message);

            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }

        private void WriteToDatabase(IEnumerable<IFileContent> sales, string managerLastName)
        {
            SaleUnitOfWork.Add(CreateDataTransferObjects(sales, managerLastName).ToArray());
        }

        private IEnumerable<SaleDto> CreateDataTransferObjects(IEnumerable<IFileContent> fileContents,
            string managerLastName)
        {
            try
            {
                var dateFormat = ConfigurationManager.AppSettings["dateFormat"];
                var customerNameSplitter = char.Parse(ConfigurationManager.AppSettings["customerNameSplitter"]);

                return (from fileContent in fileContents
                        let date = DateTime.ParseExact(fileContent.Date, dateFormat, null)
                        let customerName = Parser.ParseLine(fileContent.Customer, customerNameSplitter)
                        let customerDto = new CustomerDto(customerName[0], customerName[1])
                        let productDto = new ProductDto(fileContent.Product)
                        let sum = decimal.Parse(fileContent.Sum)
                        let managerDto = new ManagerDto(managerLastName)
                        select new SaleDto(date, customerDto, productDto, sum, managerDto))
                    .ToList();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new FormatException("Customer Field Must Contain First and Last Name");
            }
        }
    }
}
