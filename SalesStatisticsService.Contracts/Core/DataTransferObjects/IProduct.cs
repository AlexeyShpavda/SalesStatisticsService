﻿namespace SalesStatisticsService.Contracts.Core.DataTransferObjects
{
    public interface IProduct : IDataTransferObject
    {
        string Name { get; set; }
    }
}