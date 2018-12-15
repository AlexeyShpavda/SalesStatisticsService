using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public class ProductDto : DataTransferObject
    {
        public string Name { get; set; }

        public ProductDto(string name)
        {
            Name = name;
        }
    }
}