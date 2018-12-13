namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface IProduct
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}