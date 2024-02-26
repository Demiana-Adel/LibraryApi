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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsServices _authorsServices;
        private readonly ICountriesServices _countriesServices;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorsServices authorsServices, IMapper mapper, ICountriesServices countriesServices)
        {

            _authorsServices = authorsServices;
            _mapper = mapper;
            _countriesServices = countriesServices;
        }
        private List<string> _allowedExtensions= new List<string> { ".jpg" , ".png"};
        private double _maxSize = 1048576;
       
        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            var authors= await _authorsServices.GetAll();
            var data = _mapper.Map<IEnumerable<authorsDetailsDto>>(authors);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var authors = await _authorsServices.GetById(id);
            var data = _mapper.Map<authorsDetailsDto>(authors);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> createAsync([FromForm]AuthorsDto dto )
        {
           

                if (!_allowedExtensions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                    return BadRequest("Only .jpg and .png images are allowed !");
                if (dto.Image.Length > _maxSize)
                    return BadRequest("Max allowed size for Author’s image is 1MB !");
                var isvalidCountry =await _countriesServices.Isvalid(dto.CountryId);
                if (!isvalidCountry)
                    return BadRequest("Invalid Country ID !");
                using var datastream = new MemoryStream();
                await dto.Image.CopyToAsync(datastream);

            var author =_mapper.Map<Author>(dto);
            author.Image=datastream.ToArray();
                await _authorsServices.Add(author);

                return Ok(author);
       
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromForm] AuthorsDto dto)
        {
            var author = await _authorsServices.GetById(id);
            if (author ==null )
                return NotFound ($"No Author with ID {id}");
            var isvalidCountry = await _countriesServices.Isvalid(dto.CountryId);
            if (!isvalidCountry)
                return BadRequest("Invalid Country ID !");
            if (dto.Image==null)
            {
                if (!_allowedExtensions.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
                    return BadRequest("Only .jpg and .png images are allowed !");
                if (dto.Image.Length > _maxSize)
                    return BadRequest("Max allowed size for Author’s image is 1MB !");

                using var datastream = new MemoryStream();
                await dto.Image.CopyToAsync(datastream);
                author.Image = datastream.ToArray();
            }

            author.Name=dto.Name;
            author.BirthDate=dto.BirthDate;
            author.CountryId=dto.CountryId;
            _authorsServices.Update(author);

            return Ok(author);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var author = await _authorsServices.GetById(id);
            if (author == null)
                return NotFound($"No Author with ID {id}");
           _authorsServices.Delete(author);
            return Ok(author);
        }

        }
    }
