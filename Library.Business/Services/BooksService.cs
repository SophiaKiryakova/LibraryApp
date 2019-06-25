using System.Linq;
using Library.Business.Contracts;
using Library.Data;
using Library.Data.Models;

namespace Library.Business.Services
{
    public class BooksService : ServiceBase<Book>, IBooksService
    {
        public BooksService(LibraryDbContext context, IAuthorsService authorsService)
            :base(context)
        {
            this.context = context;
            this.authorsService = authorsService;
        }

        public IQueryable<Book> GetBooksForAuthor(int authorId)
        {
            return this.context.Books
                .Where(b => b.AuthorId == authorId)
                .OrderBy(b => b.Title);
        }

        public Book GetBookForAuthor(int id, int authorId)
        {
            return this.context.Books
                .Where(b => b.AuthorId == authorId && b.Id == id)
                .FirstOrDefault();
        }

        private readonly LibraryDbContext context;

        private readonly IAuthorsService authorsService;
    }
}
