using System;

namespace SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract
{
    public abstract class DataTransferObject
    {
        public int? Id { get; set; } = null;
    }
}