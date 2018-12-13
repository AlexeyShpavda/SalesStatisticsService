using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core.DataTransferObjects
{
    public class Sale : ISale
    {
        public int Id { get; set; }

        public System.DateTime Date { get; set; }

        public decimal Sum { get; set; }

        public ICustomer Customer { get; set; }
        public IManager Manager { get; set; }
        public IProduct Product { get; set; }
    }
}