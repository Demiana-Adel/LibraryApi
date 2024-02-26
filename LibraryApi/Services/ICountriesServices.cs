using LibraryApi.Data;

namespace LibraryApi.Services
{
    public interface ICountriesServices
    {
       Task<IEnumerable<Country>> GetAll();
       Task<Country> GetById(byte id);
        Task<Country> Add(Country country );
       Country Delete(Country country );
       Task<bool> Isvalid(byte id);

    }
}
