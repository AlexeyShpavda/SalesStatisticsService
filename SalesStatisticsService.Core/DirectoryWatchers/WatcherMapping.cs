using System.IO;
using SalesStatisticsService.Contracts.Core;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal static class WatcherMapping
    {
        internal static void AddEventHandlers(FileSystemWatcher fileSystemWatcher, IController controller)
        {
            fileSystemWatcher.Created += controller.ProcessFile;
        }

        internal static void RemoveEventHandlers(FileSystemWatcher fileSystemWatcher, IController controller)
        {
            fileSystemWatcher.Created -= controller.ProcessFile;
        }
    }
}