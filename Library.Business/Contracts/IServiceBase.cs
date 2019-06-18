using System.Collections.Generic;
using System.Linq;

namespace Library.Business.Contracts
{
    public interface IServiceBase<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllAndDeleted();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void Update(T entity);
    }
}
