using System;
using System.IO;
using System.Security.Permissions;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DirectoryWatchers;
using SalesStatisticsService.Core.FileProcessing;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        private FileSystemWatcher FileSystemWatcher { get; }

        private ILogger Logger { get; }

        public DirectoryWatcher(string directoryPath, string filesFilter, ILogger logger)
        {
            try
            {
                Logger = logger;

                FileSystemWatcher = new FileSystemWatcher
                {
                    Path = directoryPath,
                    Filter = filesFilter,

                    NotifyFilter = NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName
                                   | NotifyFilters.DirectoryName
                };
            }
            catch (ArgumentException)
            {
                Logger.WriteLine("Check out Path to Directory to Track in AppConfig file.");
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run(FileHandler fileHandler)
        {
            try
            {
                WatcherMapping.AddEventHandlers(FileSystemWatcher, fileHandler);

                FileSystemWatcher.EnableRaisingEvents = true;
            }
            catch (ArgumentNullException)
            {
                Logger.WriteLine("Set Path to Directory to Track in AppConfig file.");
            }
            catch (Exception)
            {
                Logger.WriteLine("AN ERROR HAS OCCURRED! Check AppConfig file.");
            }
        }

        public void Stop(FileHandler fileHandler)
        {
            WatcherMapping.RemoveEventHandlers(FileSystemWatcher, fileHandler);

            FileSystemWatcher.EnableRaisingEvents = false;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    FileSystemWatcher.Dispose();
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