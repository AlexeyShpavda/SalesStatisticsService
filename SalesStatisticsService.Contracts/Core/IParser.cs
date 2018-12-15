using System.Collections.Generic;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IParser
    {
        IEnumerable<SaleDto> ParseFile(string filePath);
    }
}