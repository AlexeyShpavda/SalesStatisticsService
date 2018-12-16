using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.DataAccessLayer.Repositories.Abstract;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class ProductRepository : GenericRepository<ProductDto, Product>, IProductRepository
    {
        public ProductRepository(SalesInformationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int? AddUniqueProductToDatabase(ProductDto productDto)
        {
            Expression<Func<ProductDto, bool>> predicate = x => x.Name == productDto.Name;

            if (Find(predicate).Any()) return Find(predicate).First().Id;

            Add(productDto);

            return Find(predicate).First().Id;
        }
    }
}