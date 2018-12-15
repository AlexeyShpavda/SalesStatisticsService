using System.Collections.Generic;

namespace SalesStatisticsService.Contracts.Entity
{
    public interface ICustomerEntity : IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        ICollection<ISaleEntity> Sales { get; set; }
    }
}