using Microsoft.EntityFrameworkCore;

namespace HomeLibraryManager.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=E:\Portfolio\FullStack\HomeLibraryManager\Database\Library.db;");
            
        }
    }
}
