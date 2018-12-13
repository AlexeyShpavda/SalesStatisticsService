namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface ISale
    {
        int Id { get; set; }

        System.DateTime Date { get; set; }

        decimal Sum { get; set; }
    }
}