using System;
using System.Collections.Generic;
using System.Threading;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Contracts.Core.FileProcessing;
using SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.Core.DirectoryWatchers;
using SalesStatisticsService.Core.FileProcessing;
using SalesStatisticsService.DataAccessLayer.UnitOfWorks;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.Core
{
    public class Controller : IController, IDisposable
    {
        private SalesInformationContext Context { get; }
        private ReaderWriterLockSlim Locker { get; }

        private IDirectoryWatcher DirectoryWatcher { get; }
        private ISaleUnitOfWork SaleUnitOfWork { get; }
        private IParser Parser { get; }
        private ILogger Logger { get; }
        private IFileHandler FileHandler { get; }

        public Controller(string directoryPath, string filesFilter)
        {
            Context = new SalesInformationContext();

            Locker = new ReaderWriterLockSlim();

            Logger = new Logger();

            DirectoryWatcher = new DirectoryWatcher(directoryPath, filesFilter, Logger);

            SaleUnitOfWork = new SaleUnitOfWork(Context, Locker);

            Parser = new Parser();

            FileHandler = new FileHandler(SaleUnitOfWork, Parser, Logger, Locker);
        }

        public void Run()
        {
            DirectoryWatcher.Run(FileHandler);
        }

        public void Stop()
        {
            DirectoryWatcher.Stop(FileHandler);
        }

        public IEnumerable<SaleDto> ShowAllSales()
        {
            return SaleUnitOfWork.GetAll();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DirectoryWatcher.Dispose();
                    Locker.Dispose();
                    Context.Dispose();
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