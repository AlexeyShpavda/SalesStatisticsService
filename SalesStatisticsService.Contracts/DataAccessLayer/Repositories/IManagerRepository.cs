using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface IManagerRepository : IGenericRepository<ManagerDto>
    {
        void AddUniqueManagerToDatabase(ManagerDto managerDto);

        int? GetId(string managerLastName);
    }
}