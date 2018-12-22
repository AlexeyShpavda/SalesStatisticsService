using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using SalesStatisticsService.Contracts.Core;
using static System.String;

namespace SalesStatisticsService.Core.FileProcessing
{
    public class Parser : Contracts.Core.IParser
    {
        public IEnumerable<IFileContent> ParseFile(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(streamReader);

                foreach (var record in csvReader.GetRecords<FileContent>())
                {
                    yield return record.Product != Empty &&
                                 record.Customer != Empty &&
                                 record.Date != Empty &&
                                 record.Sum != Empty
                        ? record
                        : throw new FormatException("File Should Not Contain Empty Fields");
                }
            }
        }

        public IList<string> ParseLine(string line, char separator)
        {
            return line.Split(separator);
        }
    }
}