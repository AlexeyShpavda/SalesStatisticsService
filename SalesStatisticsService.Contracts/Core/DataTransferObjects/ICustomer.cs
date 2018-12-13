namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface ICustomer
    {
        int Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}