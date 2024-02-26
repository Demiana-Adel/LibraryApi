using LibraryApi.Data;
using LibraryApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly ApplicationDbContext _context;

        public BooksServices(ApplicationDbContext context)
        {
            _context = context;
 
}

        public async  Task<IEnumerable<Book>> GetAll(byte genreId=0 , int authorId= 0)
        {
           
            return await _context.Books.Include(b=>b.Genre).Include(b=> b.Author)
                .Where(b=>b.GenreId==genreId || genreId==0 && b.AuthorId==authorId || authorId ==0 )
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.Include(b => b.Genre).Include(b => b.Author).SingleOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Book> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
            return book;
        }

        public Book Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }
      

    }
}
