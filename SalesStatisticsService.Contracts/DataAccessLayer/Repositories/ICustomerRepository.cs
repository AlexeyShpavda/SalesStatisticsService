using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface ICustomerRepository : IGenericRepository<CustomerDto>
    {
        void AddUniqueCustomerToDatabase(CustomerDto customerDto);

        int? GetId(string customerFirstName, string customerLastName);
    }
}