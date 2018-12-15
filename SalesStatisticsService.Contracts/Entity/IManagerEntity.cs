using System.Collections.Generic;

namespace SalesStatisticsService.Contracts.Entity
{
    public interface IManagerEntity : IEntity
    {
        string LastName { get; set; }

        ICollection<ISaleEntity> Sales { get; set; }
    }
}