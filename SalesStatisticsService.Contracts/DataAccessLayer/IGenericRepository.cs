using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SalesStatisticsService.Contracts.DataAccessLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void Remove(params TEntity[] entities);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}