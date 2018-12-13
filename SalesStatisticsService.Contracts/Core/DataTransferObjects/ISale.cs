namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface ISale : IDataTransferObject
    {
        System.DateTime Date { get; set; }

        decimal Sum { get; set; }

        ICustomer Customer { get; set; }
        IManager Manager { get; set; }
        IProduct Product{ get; set; }
    }
}