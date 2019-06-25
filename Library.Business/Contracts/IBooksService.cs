using Library.Data.Models;
using System.Linq;

namespace Library.Business.Contracts
{
    public interface IBooksService: IServiceBase<Book>
    {
        IQueryable<Book> GetBooksForAuthor(int authorId);

        Book GetBookForAuthor(int id, int authorId);
    }
}
