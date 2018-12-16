using System;

namespace SalesStatisticsService.Contracts.Core.DirectoryWatchers
{
    public interface IDirectoryWatcher : IDisposable
    {
        void Run(IController controller);

        void Stop(IController controller);
    }
}