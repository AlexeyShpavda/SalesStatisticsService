﻿namespace SalesStatisticsService.Contracts.Core.DirectoryWatchers
{
    public interface IDirectoryWatcher
    {
        void Run();

        void Stop();
    }
}