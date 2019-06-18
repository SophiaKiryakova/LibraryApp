using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllAndDeleted();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void Update(T entity);
    }
}
