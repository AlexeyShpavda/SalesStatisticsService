using System.IO;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal static class WatcherMapping
    {
        internal static void AddEventHandlers(FileSystemWatcher fileSystemWatcher)
        {
            fileSystemWatcher.Changed += WatcherEventHandler.OnChanged;
            fileSystemWatcher.Created += WatcherEventHandler.OnChanged;
            fileSystemWatcher.Deleted += WatcherEventHandler.OnChanged;
            fileSystemWatcher.Renamed += WatcherEventHandler.OnRenamed;
        }

        internal static void RemoveEventHandlers(FileSystemWatcher fileSystemWatcher)
        {
            fileSystemWatcher.Changed -= WatcherEventHandler.OnChanged;
            fileSystemWatcher.Created -= WatcherEventHandler.OnChanged;
            fileSystemWatcher.Deleted -= WatcherEventHandler.OnChanged;
            fileSystemWatcher.Renamed -= WatcherEventHandler.OnRenamed;
        }
    }
}