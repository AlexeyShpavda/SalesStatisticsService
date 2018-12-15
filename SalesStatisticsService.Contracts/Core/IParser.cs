using System.Collections.Generic;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.Core
{
    public interface IParser
    {
        IEnumerable<IFileContent> ParseFile(string filePath);

        IList<string> ParseLine(string fileName, char separator);
    }
}