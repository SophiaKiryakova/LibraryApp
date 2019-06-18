using Library.Data.Contracts;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Library.Data
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) 
                || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
