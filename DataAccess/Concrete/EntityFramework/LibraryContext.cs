using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.EntityFramework
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Library;Trusted_Connection=true");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
    }
}
