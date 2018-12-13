namespace SalesStatisticsService.Entity.Factories
{
    public class SalesInformationContextFactory
    {
        public System.Data.Entity.DbContext CreateInstance()
        {
            return new SalesInformationContext();
        }
    }
}