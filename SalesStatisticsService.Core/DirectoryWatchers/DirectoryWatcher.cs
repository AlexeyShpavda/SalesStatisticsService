using System;
using System.Configuration;
using System.IO;
using System.Security.Permissions;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        private FileSystemWatcher FileSystemWatcher { get; }

        public DirectoryWatcher()
        {
            FileSystemWatcher = new FileSystemWatcher
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
            WatcherMapping.AddEventHandlers(FileSystemWatcher, controller);

            // check for the value of the path and filter
            FileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop(IController controller)
        {
            WatcherMapping.RemoveEventHandlers(FileSystemWatcher, controller);

            FileSystemWatcher.EnableRaisingEvents = false;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    lock (this)
                    {
                        FileSystemWatcher.Dispose();
                    }
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}