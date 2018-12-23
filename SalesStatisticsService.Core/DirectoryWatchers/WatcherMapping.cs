using System.IO;
using SalesStatisticsService.Core.FileProcessing;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal static class WatcherMapping
    {
        internal static void AddEventHandlers(FileSystemWatcher fileSystemWatcher, FileHandler fileHandler)
        {
            fileSystemWatcher.Created += fileHandler.ProcessFile;
        }

        internal static void RemoveEventHandlers(FileSystemWatcher fileSystemWatcher, FileHandler fileHandler)
        {
            fileSystemWatcher.Created -= fileHandler.ProcessFile;
        }
    }
}