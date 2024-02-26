using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class GenresServices : IGenresServices
    {
        private readonly ApplicationDbContext _context;

        public GenresServices(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }
        public async  Task<Genre> GetById(byte id)
        {
            return await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
        }


        public async  Task<Genre> Add(Genre genre)
        {
            await _context.AddAsync(genre);
            _context.SaveChanges();
            return genre;
        }

       
        public Genre Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return genre;
        }

        public async  Task<bool> IsvalidGenre(byte id)
        {
            return await _context.Genres.AnyAsync(g => g.Id == id);
        }
    }
}
