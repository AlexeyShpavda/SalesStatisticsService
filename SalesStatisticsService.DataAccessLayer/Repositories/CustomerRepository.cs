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
    public class CustomerRepository : GenericRepository<CustomerDto, Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesInformationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int? AddUniqueCustomerToDatabase(CustomerDto customerDto)
        {
            Expression<Func<CustomerDto, bool>> predicate = x =>
                x.LastName == customerDto.LastName && x.FirstName == customerDto.FirstName;

            if (Find(predicate).Any()) return Find(predicate).First().Id;

            Add(customerDto);

            return Find(predicate).First().Id;
        }
    }
}