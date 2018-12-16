using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface IGenericRepository<TDto> where TDto : DataTransferObject
    {
        void Add(params TDto[] models);

        void Update(params TDto[] entities);

        void Remove(params TDto[] entities);

        TDto Get(int id);

        IQueryable<TDto> GetAll();

        IEnumerable<TDto> Find(Expression<Func<TDto, bool>> predicate);

        void Save();
    }
}