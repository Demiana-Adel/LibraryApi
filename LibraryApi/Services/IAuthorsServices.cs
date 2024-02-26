using LibraryApi.Data;

namespace LibraryApi.Services
{
    public interface IAuthorsServices
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Add(Author author);
        Author Update(Author author);
        Author Delete(Author author);
        Task<bool> IsvalidAuthor(int id);


    }
}
