﻿using System;
using System.IO;

namespace SalesStatisticsService.Core.DirectoryWatchers
{
    internal class WatcherEventHandler
    {
        internal static void OnCreated(object source, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        //internal static void OnDeleted(object source, FileSystemEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //internal static void OnRenamed(object source, RenamedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}