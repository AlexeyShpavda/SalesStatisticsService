using SalesStatisticsService.Core;

namespace SalesStatisticsService.Console
{
    internal class Program
    {
        private static void Main()
        {
            using (var controller = new Controller())
            {
                controller.Run();
              
                System.Console.ReadKey();

                controller.Stop();
            }
        }
    }
}