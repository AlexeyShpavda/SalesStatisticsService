using System;

namespace SalesStatisticsService.Contracts.Entity
{
    public interface ISaleEntity : IEntity
    {
        int ManagerId { get; set; }
        int ProductId { get; set; }
        int CustomerId { get; set; }
        System.DateTime Date { get; set; }
        decimal Sum { get; set; }

        IManagerEntity Manager { get; set; }
        IProductEntity Product { get; set; }
        ICustomerEntity Customer { get; set; }
    }
}