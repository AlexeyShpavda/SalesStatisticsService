using System.ServiceProcess;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Core;

namespace SalesStatisticsService.Service
{
    public partial class WindowsService : ServiceBase
    {
        private readonly IController _controller;

        public WindowsService()
        {
            InitializeComponent();

            _controller = new Controller();
        }

        protected override void OnStart(string[] args)
        {
            _controller.Run();
        }

        protected override void OnStop()
        {
            _controller.Stop();
        }
    }
}
