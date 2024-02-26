using LibraryApi.Data;

namespace LibraryApi.Services
{
    public class CountriesServices : ICountriesServices
    {
        private readonly ApplicationDbContext _context;

        public CountriesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();  
            
        }

        public async Task<Country> GetById(byte id)
        {
            return await _context.Countries.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async  Task<Country> Add(Country country)
        {
           await  _context.Countries.AddAsync(country);
            _context.SaveChanges();
            return country;
        }

        public Country Delete(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return country;
        }

        public async Task<bool> Isvalid(byte id)
        {
           return await  _context.Countries.AnyAsync(c => c.Id == id);
        }
    }
}
