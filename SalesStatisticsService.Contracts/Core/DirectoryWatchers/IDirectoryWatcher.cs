namespace SalesStatisticsService.Contracts.Core.DirectoryWatchers
{
    public interface IDirectoryWatcher
    {
        void Run(IController controller);

        void Stop(IController controller);
    }
}