using System.IO;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IController
    {
        void Run();

        void Stop();

        void ProcessFile(object source, FileSystemEventArgs e);
    }
}