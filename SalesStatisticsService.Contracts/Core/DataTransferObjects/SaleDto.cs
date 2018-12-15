using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public class SaleDto : DataTransferObject
    {
        public DateTime Date { get; set; }

        public CustomerDto Customer { get; set; }

        public ProductDto Product { get; set; }

        public decimal Sum { get; set; }

        public ManagerDto Manager { get; set; }
    }
}