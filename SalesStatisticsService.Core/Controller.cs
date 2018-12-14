using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Core.DirectoryWatchers;
using SalesStatisticsService.Entity;
using IParser = SalesStatisticsService.Contracts.Core.IParser;

namespace SalesStatisticsService.Core
{
    public class Controller : IController
    {
        private readonly IDirectoryWatcher _directoryWatcher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParser _parser;

        public Controller()
        {
            _directoryWatcher = new DirectoryWatcher();

            _unitOfWork = new UnitOfWork(new SalesInformationContext());

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
            var task = Task<IEnumerable<ISale>>.Factory.StartNew(() => _parser.ParseFile(e.FullPath));

            task.ContinueWith((t, o) => WriteToDatabase(t.Result), null,
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void WriteToDatabase(IEnumerable<ISale> sales)
        {
            foreach (var sale in sales)
            {
                _unitOfWork.Sales.Add(sale);
            }
        }
    }
}