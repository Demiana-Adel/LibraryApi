using AutoMapper;
using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBooksServices _booksServices;
        private readonly IGenresServices _genresServices ;
        private readonly IAuthorsServices _authorsServices ;
        private readonly IMapper _mapper ;

        public BooksController(ApplicationDbContext context, IBooksServices booksServices, IMapper mapper, IGenresServices genresServices = null, IAuthorsServices authorsServices = null)
        {
            _context = context;
            _booksServices = booksServices;
            _mapper = mapper;
            _genresServices = genresServices;
            _authorsServices = authorsServices;
        }
        private List<string> _allowedExtensios=new List<string> { ".jpg" ,".png"};
        private double _maxSize = 1048576;
        [HttpGet ]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _booksServices.GetAll();
            var data=_mapper.Map<IEnumerable<BooksDetailsDto>>(books); 
            return Ok(data);    
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var books = await _booksServices.GetById(id);
            var data = _mapper.Map<BooksDetailsDto>(books);
            return Ok(data);
        }
        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(byte genreId)
        {
            var books = await _booksServices.GetAll(genreId);
            var data = _mapper.Map<IEnumerable<BooksDetailsDto>>(books);
            return Ok(data);
        }
        [HttpGet("GetByAuthorId")]
        public async Task<IActionResult> GetByAuthorIdAsync(byte authorId)
        {
            var books = await _booksServices.GetAll(authorId);
            var data = _mapper.Map<IEnumerable<BooksDetailsDto>>(books);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> createAsync([FromForm]BooksDto dto )
        {
            if (! _allowedExtensios.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest ("Only allowed Extinsion images are .jpg and .png !");
            if (dto.Poster.Length >_maxSize )
                return BadRequest ("Max size is allowed 1MB !");
            var isvalidGenre =await  _context.Genres.AnyAsync(g=>g.Id ==dto.GenreId);
            if (!isvalidGenre)
                return BadRequest("Invalid Genre ID!");
            var isvalidAuthor = await _context.Authors.AnyAsync(a => a.Id == dto.AuthorId);
            if (!isvalidGenre)
                return BadRequest("Invalid Author ID!");
            using var datastream = new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);

            var book = _mapper.Map<Book>(dto);
                book.Poster= datastream.ToArray();
            await _booksServices.Add(book);
            return Ok(book);
        }
       

        [HttpPut("{id}")]

      
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] BooksDto dto)
        {
            var book = await _booksServices.GetById(id);
            if (book == null)
                return NotFound($"No Book with ID {id} !");
            var isvalidGenre = await _genresServices.IsvalidGenre(dto.GenreId);
            if (!isvalidGenre)
                return BadRequest("Invalid Genre ID!");
            var isvalidAuthor = await _authorsServices.IsvalidAuthor(dto.AuthorId);
            if (!isvalidAuthor)
                return BadRequest("Invalid Author ID!");
            if (dto.Poster ==null)
            {
                if (!_allowedExtensios.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Only allowed Extinsion images are .jpg and .png !");
                if (dto.Poster.Length > _maxSize)
                    return BadRequest("Max size is allowed 1MB !");
                using var datastream = new MemoryStream();
                await dto.Poster.CopyToAsync(datastream);
                book.Poster = datastream.ToArray();
            }


            book.Title = dto.Title;
            book.GenreId= dto.GenreId;  
            book.AuthorId=dto.AuthorId;
            _booksServices.Update(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var book= await _booksServices.GetById(id);
            if (book == null)
                return NotFound($"No Book with ID {id} !");
             _booksServices.Delete(book);
            return Ok(book);
        }

     }
}
