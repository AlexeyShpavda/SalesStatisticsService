using System.Collections.Generic;

namespace SalesStatisticsService.Contracts.Core.FileProcessing
{
    public interface IParser
    {
        IEnumerable<IFileContent> ParseFile(string filePath);

        IList<string> ParseLine(string fileName, char separator);
    }
}