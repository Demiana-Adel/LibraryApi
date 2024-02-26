using LibraryApi.Data;

namespace LibraryApi.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        private readonly ApplicationDbContext _context;

        public AuthorsServices(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.Include(a=>a.Country).ToListAsync();
     
        }

        public async Task<Author> GetById(int id)
        {
            return await _context.Authors.Include(a=>a.Country).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async  Task<Author> Add(Author author)
        {
            await _context.Authors.AddAsync(author);
            _context.SaveChanges();
            return author;
        }

        public Author Update(Author author)
        {
            _context.Update(author);
            _context.SaveChanges();
            return author;

        }

        public Author Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return author;
        }

        public async  Task<bool> IsvalidAuthor(int id)
        {
            return await _context.Authors.AnyAsync(a => a.Id == id);
        }
    }
}
