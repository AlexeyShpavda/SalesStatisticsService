﻿using System.Collections.Generic;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;

namespace SalesStatisticsService.Contracts.DataAccessLayer.UnitOfWorks
{
    public interface ISaleUnitOfWork
    {
        void Add(params SaleDto[] models);

        IEnumerable<SaleDto> GetAll();
    }
}