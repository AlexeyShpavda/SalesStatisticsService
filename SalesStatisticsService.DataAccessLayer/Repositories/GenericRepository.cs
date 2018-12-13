using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IDataTransferObject 
    {
        private readonly SalesInformationContext _context;

        private readonly IMapper _mapper;

        public GenericRepository(SalesInformationContext context)
        {
            _context = context;

            _mapper = AutoMapper.CreateConfiguration().CreateMapper();
        }

        public void Add(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Remove(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(entity);
                }

                _context.Set<TEntity>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}