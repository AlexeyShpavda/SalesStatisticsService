namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface IManager : IDataTransferObject
    {
        string LastName { get; set; }
    }
}