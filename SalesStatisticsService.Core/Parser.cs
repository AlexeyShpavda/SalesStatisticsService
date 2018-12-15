using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core
{
    public class Parser : Contracts.Core.IParser
    {
        public IEnumerable<SaleDto> ParseFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(streamReader);

                return csvReader.GetRecords<SaleDto>().ToList();
            }
        }
    }
}