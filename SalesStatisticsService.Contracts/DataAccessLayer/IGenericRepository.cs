using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SalesStatisticsService.Contracts.DataAccessLayer
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void Remove(params TEntity[] entities);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}