using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core.DataTransferObjects
{
    public class Product : IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}