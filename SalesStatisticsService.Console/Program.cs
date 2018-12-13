using SalesStatisticsService.Core.DirectoryWatchers;

namespace SalesStatisticsService.Console
{
    internal class Program
    {
        private static void Main()
        {
            var directoryWatcher = new DirectoryWatcher();

            directoryWatcher.Run();

            System.Console.ReadKey();
        }
    }
}