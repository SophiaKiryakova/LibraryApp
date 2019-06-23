using Library.Business.Contracts;
using Library.Data;
using Library.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Business.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T>
        where T : class
    {
        public ServiceBase(LibraryDbContext context)
        {
            this.context = context != null ? context : throw new ArgumentNullException("An instance of LibraryContext is required to use this repository.");
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet.AsQueryable();
            // .Where(e => !e.IsDeleted)
        }

        public IQueryable<T> GetAllAndDeleted()
        {
            return this.dbSet.AsQueryable();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }

            EntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }

            this.context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }

            //entity.IsDeleted = true;
            //entity.DeletedOn = DateTime.Now;

            var entry = this.context.Entry(entity);

            if (entry.State != EntityState.Modified)
            {
                entry.State = EntityState.Modified;
            }

            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }

            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
            this.context.SaveChanges();
        }

        private readonly LibraryDbContext context;

        private DbSet<T> dbSet;
    }
}
