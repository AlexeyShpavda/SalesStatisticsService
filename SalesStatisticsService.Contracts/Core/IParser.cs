using System.Collections.Generic;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IParser
    {
        IEnumerable<ISale> ParseFile(string filePath);

        string ParseFileName(string name);
    }
}