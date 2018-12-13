using System.Configuration;
using System.IO;
using System.Security.Permissions;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public DirectoryWatcher()
        {
            _fileSystemWatcher = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["csvFilesPath"],
                NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName,
                Filter = "*.csv"
            };
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        { 
            WatcherMapping.AddEventHandlers(_fileSystemWatcher);

            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            WatcherMapping.RemoveEventHandlers(_fileSystemWatcher);

            _fileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}