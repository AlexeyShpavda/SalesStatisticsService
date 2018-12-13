namespace SalesStatisticsService.Contracts.Entity
{
    public interface ICustomerEntity : IEntity
    {
        string FirstName { get; set; }

        string LastName { get; set; }
    }
}