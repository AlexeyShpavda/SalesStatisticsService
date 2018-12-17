using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SalesStatisticsService.Core;

namespace SalesStatisticsService.WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Controller _controller;

        public Service1()
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
