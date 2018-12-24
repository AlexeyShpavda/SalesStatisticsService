using System.IO;

namespace SalesStatisticsService.Contracts.Core.FileProcessing
{
    public interface IFileHandler
    {
        void ProcessFile(object source, FileSystemEventArgs e);
    }
}