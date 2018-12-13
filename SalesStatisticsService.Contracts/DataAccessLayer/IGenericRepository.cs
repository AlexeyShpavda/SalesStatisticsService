using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.Entity;

namespace SalesStatisticsService.Contracts.DataAccessLayer
{
    public interface IGenericRepository<TModel, TEntity> : IDisposable
        where TModel : class, IDataTransferObject
        where TEntity : class, IEntity
    {
        void Add(params TModel[] models);

        void Update(params TModel[] entities);

        void Remove(params TModel[] entities);

        TModel Get(int id);

        IEnumerable<TModel> GetAll();

        IEnumerable<TModel> Find(Expression<Func<TEntity, bool>> predicate);
    }
}