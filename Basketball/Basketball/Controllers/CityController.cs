using Basketball.Models;
using Basketball.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // get all
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var cities = await _cityService.GetAllCities();
            return Ok(cities);
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _cityService.GetCity(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // post create
        [HttpPost]
        public async Task<ActionResult<City>> CreateBasketballClub(City city)
        {
            await _cityService.CreateCity(city);

            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }
    }
}
