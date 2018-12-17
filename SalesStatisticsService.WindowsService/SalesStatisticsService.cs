using System.Configuration;
using System.ServiceProcess;
using SalesStatisticsService.Core;

namespace SalesStatisticsService.WindowsService
{
    public partial class SalesStatisticsService : ServiceBase
    {
        private Controller _controller;

        public SalesStatisticsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var directoryPath = ConfigurationManager.AppSettings["directoryPath"];
            var filesFilter = ConfigurationManager.AppSettings["filesFilter"];

            _controller = new Controller(directoryPath, filesFilter);
        }

        protected override void OnStop()
        {
            _controller.Stop();
            _controller.Dispose();
        }
    }
}
