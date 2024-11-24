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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cityService.CreateCity(city);

            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        // put update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            var updatedCity = await _cityService.UpdateCity(id, city);

            if (updatedCity == null)
            {
                return NotFound();
            }

            return Ok(updatedCity);
        }

        // delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var city = await _cityService.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityService.DeleteCity(id);
            return NoContent();
        }
    }
}
