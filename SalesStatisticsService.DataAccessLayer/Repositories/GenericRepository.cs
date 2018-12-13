using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SalesStatisticsService.Contracts.DataAccessLayer;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        public void Add(params TEntity[] entities)
        {
            using (var context = new SalesInformationContext())
            {
                foreach (var entity in entities)
                {
                    context.Set<TEntity>().Add(entity);
                    context.Entry(entity).State = EntityState.Added;
                }

                context.SaveChanges();
            }
        }

        public void Update(params TEntity[] entities)
        {
            using (var context = new SalesInformationContext())
            {
                foreach (var entity in entities)
                {
                    context.Set<TEntity>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }

        public void Remove(params TEntity[] entities)
        {
            using (var context = new SalesInformationContext())
            {
                foreach (var entity in entities)
                {
                    if (context.Entry(entity).State == EntityState.Detached)
                    {
                        context.Set<TEntity>().Attach(entity);
                    }

                    context.Set<TEntity>().Remove(entity);
                    context.Entry(entity).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var context = new SalesInformationContext())
            {
                return context.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = new SalesInformationContext())
            {
                return context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
            }
        }
    }
}