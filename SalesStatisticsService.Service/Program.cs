using System.ServiceProcess;

namespace SalesStatisticsService.Service
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new WindowsService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
