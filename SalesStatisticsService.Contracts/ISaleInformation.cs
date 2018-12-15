using SalesStatisticsService.Contracts.Core;

namespace SalesStatisticsService.Contracts
{
    public interface ISaleInformation
    {
        string ManagerName { get; set; }

        IFileContent FileContent { get; set; }
    }
}