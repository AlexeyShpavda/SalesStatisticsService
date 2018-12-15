using SalesStatisticsService.Contracts.Core;

namespace SalesStatisticsService.Core
{
    public class FileContent : IFileContent
    {
        public string Date { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public string Sum { get; set; }
    }
}