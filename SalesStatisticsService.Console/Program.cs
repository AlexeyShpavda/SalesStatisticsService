using SalesStatisticsService.Core;

namespace SalesStatisticsService.Console
{
    internal class Program
    {
        private static void Main()
        {
            var controller = new Controller();

            controller.Run();

            System.Console.ReadKey();
        }
    }
}