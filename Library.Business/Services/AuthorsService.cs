using Library.Business.Contracts;
using Library.Data;
using Library.Data.Models;

namespace Library.Business.Services
{
    public class AuthorsService: ServiceBase<Author>, IAuthorsService
    {
        public AuthorsService(LibraryDbContext context)
            : base(context)
        {
            this.context = context;
        }

        private readonly LibraryDbContext context;
    }
}
