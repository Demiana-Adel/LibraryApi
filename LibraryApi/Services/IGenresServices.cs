using LibraryApi.Data;

namespace LibraryApi.Services
{
    public interface IGenresServices
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(byte id);
        Task<Genre> Add(Genre genre);
        Genre Delete(Genre genre);
        Task<bool> IsvalidGenre(byte id);

    }
}
