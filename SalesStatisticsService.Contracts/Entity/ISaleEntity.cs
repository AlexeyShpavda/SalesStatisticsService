namespace SalesStatisticsService.Contracts.Entity
{
    public interface ISaleEntity : IEntity
    {
        System.DateTime Date { get; set; }

        decimal Sum { get; set; }
    }
}