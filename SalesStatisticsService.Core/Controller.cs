using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Core.DirectoryWatchers;

namespace SalesStatisticsService.Core
{
    public class Controller : IController
    {
        private readonly IDirectoryWatcher _directoryWatcher;
        private readonly IUnitOfWork _unitOfWork;

        public Controller()
        {
            _directoryWatcher = new DirectoryWatcher();

            _unitOfWork = new UnitOfWork();
        }

        public void Run()
        {
            _directoryWatcher.Run();
        }

        public void Stop()
        {
            _directoryWatcher.Stop();
        }
    }
}