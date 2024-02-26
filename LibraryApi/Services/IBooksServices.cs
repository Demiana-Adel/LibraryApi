using LibraryApi.Data;

namespace LibraryApi.Services
{
    public interface IBooksServices
    {
        Task<IEnumerable<Book>> GetAll(byte genreId=0 , int authorId=0);
        Task<Book> GetById(int id);

       Task<Book> Add(Book book );
       Book Update(Book book );
       Book Delete(Book book );
    }
}
