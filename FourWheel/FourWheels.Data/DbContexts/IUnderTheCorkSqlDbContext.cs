using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FourWheels.Data.DbContexts
{
    public interface IFourWheelsSqlDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}
