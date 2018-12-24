using System.IO;
using SalesStatisticsService.Contracts.Core.FileProcessing;
using SalesStatisticsService.Core.FileProcessing;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal static class WatcherMapping
    {
        internal static void AddEventHandlers(FileSystemWatcher fileSystemWatcher, IFileHandler fileHandler)
        {
            fileSystemWatcher.Created += fileHandler.ProcessFile;
        }

        internal static void RemoveEventHandlers(FileSystemWatcher fileSystemWatcher, IFileHandler fileHandler)
        {
            fileSystemWatcher.Created -= fileHandler.ProcessFile;
        }
    }
}