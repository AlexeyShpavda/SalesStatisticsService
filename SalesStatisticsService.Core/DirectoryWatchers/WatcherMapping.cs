using System.IO;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal static class WatcherMapping
    {
        internal static void AddEventHandlers(FileSystemWatcher fileSystemWatcher)
        {
            fileSystemWatcher.Created += WatcherEventHandler.OnCreated;
            fileSystemWatcher.Deleted += WatcherEventHandler.OnDeleted;
            fileSystemWatcher.Renamed += WatcherEventHandler.OnRenamed;
        }

        internal static void RemoveEventHandlers(FileSystemWatcher fileSystemWatcher)
        {
            fileSystemWatcher.Created -= WatcherEventHandler.OnCreated;
            fileSystemWatcher.Deleted -= WatcherEventHandler.OnDeleted;
            fileSystemWatcher.Renamed -= WatcherEventHandler.OnRenamed;
        }
    }
}