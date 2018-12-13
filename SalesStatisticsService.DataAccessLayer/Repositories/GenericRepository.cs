using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer;
using SalesStatisticsService.Contracts.Entity;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class GenericRepository<TModel, TEntity> : IGenericRepository<TModel, TEntity>
        where TModel: class, IDataTransferObject
        where TEntity : class, IEntity
    {
        private readonly SalesInformationContext _context;

        private readonly IMapper _mapper;

        public GenericRepository(SalesInformationContext context)
        {
            _context = context;

            _mapper = AutoMapper.CreateConfiguration().CreateMapper();
        }

        public void Add(params TModel[] models)
        {
            foreach (var model in models)
            {
                var entity = _mapper.Map<TEntity>(model);

                _context.Set<TEntity>().Add(entity);
                _context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Update(params TModel[] models)
        {
            foreach (var model in models)
            {
                var entity = _mapper.Map<TEntity>(model);

                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Remove(params TModel[] models)
        {
            foreach (var model in models)
            {
                var entity = _mapper.Map<TEntity>(model);

                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(entity);
                }

                _context.Set<TEntity>().Remove(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public TModel Get(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TEntity>().Find(id));
        }

        public IEnumerable<TModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(_context.Set<TEntity>()
                .AsNoTracking()
                .ToList());
        }

        public IEnumerable<TModel> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(_context.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .ToList());
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