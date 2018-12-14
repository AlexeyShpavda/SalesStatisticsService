using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core
{
    public class Parser : Contracts.Core.IParser
    {
        public IEnumerable<ISale> ParseFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(streamReader);

                return csvReader.GetRecords<ISale>().ToList();
            }
        }

        public string ParseFileName(string name)
        {
            return name.Split('_').First();
        }
    }
}