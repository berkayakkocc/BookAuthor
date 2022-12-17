using Core.Models.CommonEntity;
using Core.Models.PageEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BookAuthorContext : DbContext
    {
        public BookAuthorContext(DbContextOptions<BookAuthorContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntityDetail && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntityDetail)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
                else
                {
                    ((BaseEntityDetail)entityEntry.Entity).UpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
