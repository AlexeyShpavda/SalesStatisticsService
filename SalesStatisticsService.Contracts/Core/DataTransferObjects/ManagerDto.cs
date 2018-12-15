using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public class ManagerDto : DataTransferObject
    {
        public string LastName { get; set; }
    }
}