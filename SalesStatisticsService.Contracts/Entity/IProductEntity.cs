using System.Collections.Generic;

namespace SalesStatisticsService.Contracts.Entity
{
    public interface IProductEntity : IEntity
    {
        string Name { get; set; }

        ICollection<ISaleEntity> Sales { get; set; }
    }
}