using Library.Data.Models;

namespace Library.Data.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Author> AuthorsRepository { get; }
        void Save();
    }
}
