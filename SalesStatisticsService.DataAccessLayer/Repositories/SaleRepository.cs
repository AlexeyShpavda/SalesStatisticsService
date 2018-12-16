using AutoMapper;
using SalesStatisticsService.Contracts.Core.DataTransferObjects;
using SalesStatisticsService.Contracts.DataAccessLayer.Repositories;
using SalesStatisticsService.DataAccessLayer.Repositories.Abstract;
using SalesStatisticsService.Entity;

namespace SalesStatisticsService.DataAccessLayer.Repositories
{
    public class SaleRepository : GenericRepository<SaleDto, Sale>, ISaleRepository
    {
        public SaleRepository(SalesInformationContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}