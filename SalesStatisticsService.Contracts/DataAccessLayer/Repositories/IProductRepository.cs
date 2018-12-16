using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductDto>
    {
        void AddUniqueProductToDatabase(ProductDto productDto);

        int? GetId(string productName);
    }
}