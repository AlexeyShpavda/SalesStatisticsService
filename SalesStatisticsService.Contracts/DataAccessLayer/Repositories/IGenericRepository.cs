using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;

namespace SalesStatisticsService.Contracts.DataAccessLayer.Repositories
{
    public interface IGenericRepository<TModel, TEntity>
        where TModel : DataTransferObject
        where TEntity : class//, IEntity
    {
        void Add(params TModel[] models);

        void Update(params TModel[] entities);

        void Remove(params TModel[] entities);

        TModel Get(int id);

        IQueryable<TModel> GetAll();

        IEnumerable<TModel> Find(Expression<Func<TEntity, bool>> predicate);

        void Save();
    }
}