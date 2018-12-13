namespace SalesStatisticsService.Contracts.Entity
{
    public interface IManagerEntity : IEntity
    {
        string LastName { get; set; }
    }
}