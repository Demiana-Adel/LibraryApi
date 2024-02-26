

namespace LibraryApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options) { }  
       public DbSet<Country> Countries { get; set; }
       public DbSet<Genre> Genres { get; set; }
       public DbSet<Author> Authors { get; set; }
       public DbSet<Book> Books { get; set; }
    }
}
