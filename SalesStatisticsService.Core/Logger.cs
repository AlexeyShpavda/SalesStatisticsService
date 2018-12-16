using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace SalesStatisticsService.Core
{
    internal class Logger
    {
        private static string _logFilesPath = ConfigurationManager.AppSettings["filesPathForLogging"];

        private const string DefaultFilePath = @"..\..\..\log.txt";

        internal static void WriteLine(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            try
            {
                using (var streamWriter = new StreamWriter(_logFilesPath, true))
                {
                    streamWriter.WriteLine(
                        $"{DateTime.Now.ToString(CultureInfo.InvariantCulture) + ":",-21} {message}");
                }
            }
            catch (ArgumentNullException)
            {
                _logFilesPath = DefaultFilePath;

                WriteLine(message);
            }
            catch (Exception)
            {
                // Notify User Without Stopping Work
            }
        }
    }
}