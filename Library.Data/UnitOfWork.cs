using Library.Data.Contracts;
using Library.Data.Models;
using System;

namespace Library.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(LibraryDbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Author> AuthorsRepository
        {
            get { return authors ?? (authors = new GenericRepository<Author>(context)); }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private readonly LibraryDbContext context;
        private IGenericRepository<Author> authors;
    }
}
