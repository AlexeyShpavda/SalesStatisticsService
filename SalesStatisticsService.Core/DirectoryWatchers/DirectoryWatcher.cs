using System.Configuration;
using System.IO;
using System.Security.Permissions;
using SalesStatisticsService.Contracts.Core;
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
                Path = ConfigurationManager.AppSettings["filesPath"],
                Filter = ConfigurationManager.AppSettings["filesFilter"],

                NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName
            };
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run(IController controller)
        { 
            WatcherMapping.AddEventHandlers(_fileSystemWatcher, controller);

            // check for the value of the path and filter
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop(IController controller)
        {
            WatcherMapping.RemoveEventHandlers(_fileSystemWatcher, controller);

            _fileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}