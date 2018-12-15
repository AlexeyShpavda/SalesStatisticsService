using System;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IFileContent
    {
        string Date { get; set; }
        string Customer { get; set; }
        string Product { get; set; }
        string Sum { get; set; }
    }
}