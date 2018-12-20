using System.Configuration;
using SalesStatisticsService.Core;

namespace SalesStatisticsService.Console
{
    internal class Program
    {
        private static void Main()
        {
            var directoryPath = ConfigurationManager.AppSettings["directoryPath"];
            var filesFilter = ConfigurationManager.AppSettings["filesFilter"];

            using (var controller = new Controller(directoryPath, filesFilter))
            {
                controller.Run();

                System.Console.ReadKey();

                controller.Stop();
            }
        }
    }
}