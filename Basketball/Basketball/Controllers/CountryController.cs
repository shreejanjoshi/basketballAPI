using Basketball.Models;
using Basketball.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // get all
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countryService.GetCountry(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // post create
        [HttpPost]
        public async Task<ActionResult<Country>> CreateBasketballClub(Country country)
        {
            await _countryService.CreateCountry(country);

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }
    }
}
