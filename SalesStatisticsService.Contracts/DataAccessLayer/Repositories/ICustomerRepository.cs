using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface ICustomerRepository : IGenericRepository<CustomerDto>
    {
        int? AddUniqueCustomerToDatabase(CustomerDto customerDto);
    }
}