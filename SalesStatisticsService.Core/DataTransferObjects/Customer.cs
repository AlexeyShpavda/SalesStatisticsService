using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Core.DataTransferObjects
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}