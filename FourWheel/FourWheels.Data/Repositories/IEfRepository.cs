using System;
using System.Linq;

namespace FourWheels.Data.Repositories
{
    public interface IEfRepostory<T>
    where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        T GetById(Guid id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
