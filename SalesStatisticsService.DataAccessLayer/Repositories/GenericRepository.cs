using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects.Abstract;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class GenericRepository<TModel, TEntity> : IGenericRepository<TModel, TEntity>
        where TModel: DataTransferObject
        where TEntity : class
    {
        private readonly SalesInformationContext _context;

        private readonly IMapper _mapper;

        public GenericRepository(SalesInformationContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
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

        public IQueryable<TModel> GetAll()
        {
            return _mapper.Map<IQueryable<TEntity>, IQueryable<TModel>>(_context.Set<TEntity>()
                .AsNoTracking());
        }

        public IEnumerable<TModel> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TModel>>(_context.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}