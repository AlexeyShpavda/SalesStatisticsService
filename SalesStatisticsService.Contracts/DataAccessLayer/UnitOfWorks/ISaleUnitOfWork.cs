using System;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks
{
    public interface ISaleUnitOfWork : IDisposable
    {
        void Add(params SaleDto[] models);
    }
}