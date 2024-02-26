using LibraryApi.Data;
using LibraryApi.Dtos;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase 
    {
        private readonly ICountriesServices _countriesServices;

        public CountriesController(ICountriesServices countriesServices)
        {
            _countriesServices = countriesServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var contries = await _countriesServices.GetAll();
            return Ok(contries);
        }
        [HttpPost]
        public async Task<IActionResult>CreateAsync(CountriesDto dto)
        {
            var country = new Country { Name =dto.Name };
            await _countriesServices.Add(country);
            return Ok(country);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id )
        {
            var country =await _countriesServices.GetById(id);
            if (country == null) 
                return NotFound($"No Country With ID {id} !");
            _countriesServices.Delete(country);
            return Ok(country);
        }
    }
}
