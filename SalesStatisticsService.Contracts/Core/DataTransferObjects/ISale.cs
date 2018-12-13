namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface ISale : IDataTransferObject
    {
        System.DateTime Date { get; set; }

        decimal Sum { get; set; }
    }
}