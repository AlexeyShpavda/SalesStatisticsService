using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductDto>
    {
        int? AddUniqueProductToDatabase(ProductDto productDto);
    }
}