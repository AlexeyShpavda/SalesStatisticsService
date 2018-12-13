namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface ICustomer : IDataTransferObject
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}