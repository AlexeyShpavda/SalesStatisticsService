using System.Configuration;
using System.IO;
using System.Security.Permissions;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    public class DirectoryWatcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {
            var fileSystemWatcher = new FileSystemWatcher
            {
                Path = ConfigurationManager.AppSettings["csvFilesPath"],
                NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName,
                Filter = "*.csv"
            };

            WatcherMapping.AddEventHandlers(fileSystemWatcher);

            fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop(FileSystemWatcher fileSystemWatcher)
        {
            WatcherMapping.RemoveEventHandlers(fileSystemWatcher);

            fileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}