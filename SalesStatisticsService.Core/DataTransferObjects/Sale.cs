using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core.DataTransferObjects
{
    public class Sale : ISale
    {
        public int Id { get; set; }

        public System.DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}