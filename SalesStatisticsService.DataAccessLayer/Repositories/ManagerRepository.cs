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
    public class ManagerRepository : GenericRepository<ManagerDto, Manager>, IManagerRepository
    {
        public ManagerRepository(SalesInformationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public void AddUniqueManagerToDatabase(ManagerDto managerDto)
        {
            Expression<Func<ManagerDto, bool>> predicate = x => x.LastName == managerDto.LastName;

            if (Find(predicate).Any()) return;

            Add(managerDto);
        }
    }
}