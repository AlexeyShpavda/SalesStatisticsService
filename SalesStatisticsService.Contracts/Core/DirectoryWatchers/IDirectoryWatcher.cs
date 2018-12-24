using System;
using SalesStatisticsService.Contracts.Core.FileProcessing;

namespace SalesStatisticsService.Contracts.Core.DirectoryWatchers
{
    public interface IDirectoryWatcher : IDisposable
    {
        void Run(IFileHandler fileHandler);

        void Stop(IFileHandler fileHandler);
    }
}