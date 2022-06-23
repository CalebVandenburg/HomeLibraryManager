using HomeLibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryManager.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=E:\Portfolio\FullStack\HomeLibraryManager\Database\Library.db;");
            
        }

    }
}
