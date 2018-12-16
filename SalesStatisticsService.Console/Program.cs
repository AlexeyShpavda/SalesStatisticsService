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

                foreach (var sale in controller.ShowAllSales())
                {
                    System.Console.Write($"{sale.Id} ");                 
                }

                System.Console.ReadKey();

                controller.Stop();
            }
        }
    }
}