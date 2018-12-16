using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace SalesStatisticsService.Core
{
    internal class Logger
    {
        private static readonly string LogFilesPath = ConfigurationManager.AppSettings["filesPathForLogging"];

        internal static void WriteLine(string message)
        {
            using (var streamWriter = new StreamWriter(LogFilesPath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture) + ":",-21} {message}");
            }
        }
    }
}