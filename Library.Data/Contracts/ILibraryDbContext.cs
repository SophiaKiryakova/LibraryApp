using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.Data.Contracts
{
    public interface ILibraryDbContext
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Book> Books { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
  
        int SaveChanges();
    }
}
