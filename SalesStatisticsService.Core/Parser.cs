using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using SalesStatisticsService.Contracts.Core;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core
{
    public class Parser : Contracts.Core.IParser
    {
        public IEnumerable<IFileContent> ParseFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(streamReader);

                return csvReader.GetRecords<FileContent>().ToList();
            }
        }

        public IList<string> ParseLine(string line, char separator)
        {
            return line.Split(separator);
        }
    }
}