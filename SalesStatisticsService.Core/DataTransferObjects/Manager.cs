using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core.DataTransferObjects
{
    public class Manager : IManager
    {
        public int Id { get; set; }

        public string LastName { get; set; }
    }
}