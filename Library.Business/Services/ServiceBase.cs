using Library.Business.Contracts;
using Library.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Business.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T>
        where T : class
    {
        public ServiceBase(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<T> GetAllAndDeleted()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        private readonly IGenericRepository<T> repository;
    }
}
