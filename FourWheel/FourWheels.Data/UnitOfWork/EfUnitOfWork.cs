using FourWheels.Data.DbContexts;

namespace FourWheels.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly FourWheelsSqlDbContext context;

        public EfUnitOfWork(FourWheelsSqlDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}