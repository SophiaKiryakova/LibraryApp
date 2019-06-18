using Library.Business.Contracts;
using Library.Data.Contracts;
using Library.Data.Models;

namespace Library.Business.Services
{
    public class AuthorsService: ServiceBase<Author>, IAuthorsService
    {
        public AuthorsService(IGenericRepository<Author> repository)
            : base(repository)
        {
            this.repository = repository;
        }

        private readonly IGenericRepository<Author> repository;
    }
}
