namespace SalesStatisticsService.WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SalesStatisticsServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SalesStatisticsServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SalesStatisticsServiceProcessInstaller
            // 
            this.SalesStatisticsServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.SalesStatisticsServiceProcessInstaller.Password = null;
            this.SalesStatisticsServiceProcessInstaller.Username = null;
            // 
            // SalesStatisticsServiceInstaller
            // 
            this.SalesStatisticsServiceInstaller.ServiceName = "SalesStatisticsService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SalesStatisticsServiceProcessInstaller,
            this.SalesStatisticsServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SalesStatisticsServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SalesStatisticsServiceInstaller;
    }
}