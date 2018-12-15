using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public class CustomerDto : DataTransferObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerDto()
        {
        }

        public CustomerDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}