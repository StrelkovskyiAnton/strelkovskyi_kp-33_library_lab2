using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Dao
{
    public class LibraryContext: DbContext
    {
        public DbSet<Reader> readers { get; set; }
        public DbSet<Book> books { get; set; }
        public LibraryContext() : base(GetOptions()) { }

        private static DbContextOptions GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=admin123");
            return optionsBuilder.Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=admin123");
            }
        }
    }
}
