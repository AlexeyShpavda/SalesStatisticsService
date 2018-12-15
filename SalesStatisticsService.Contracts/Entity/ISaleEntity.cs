using System;

namespace SalesStatisticsService.Contracts.Entity
{
    public interface ISaleEntity : IEntity
    {
        DateTime Date { get; set; }

        decimal Sum { get; set; }
    }
}