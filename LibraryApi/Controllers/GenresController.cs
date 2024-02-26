using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresServices _genresServices;
       
       
        public GenresController(IGenresServices genresServices)
        {
            _genresServices = genresServices;
           
        }
        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            var genres = await _genresServices.GetAll();
            return Ok(genres);
        }
        [HttpPost]
        public async Task<IActionResult>  CreateAsync(GenresDto dto)
        {
            var genre = new Genre { Name = dto.Name };  
            await _genresServices.Add(genre);
            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresServices.GetById(id);
            if (genre == null)
                return NotFound($"No Genre with ID {id}");
          _genresServices.Delete(genre);
            return Ok(genre);
        }
    }
}
