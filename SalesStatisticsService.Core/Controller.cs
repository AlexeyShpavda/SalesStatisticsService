using System.Collections.Generic;
using System.IO;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Core.DirectoryWatchers;

namespace SalesStatisticsService.Core
{
    public class Controller : IController
    {
        private readonly IDirectoryWatcher _directoryWatcher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Parser _parser;

        public Controller()
        {
            _directoryWatcher = new DirectoryWatcher();

            _unitOfWork = new UnitOfWork();

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
            var sales = ParseFile(e.FullPath);

            WriteToDatabase(sales);
        }

        private void WriteToDatabase(IEnumerable<ISale> sales)
        {
            foreach (var sale in sales)
            {
                _unitOfWork.Sales.Add(sale);
            }
        }

        private IEnumerable<ISale> ParseFile(string filePath)
        {
            return _parser.ParseFile(filePath);
        }
    }
}