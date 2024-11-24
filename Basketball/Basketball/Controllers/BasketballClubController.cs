using Basketball.Models;
using Basketball.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basketball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketballClubController : Controller
    {
        private readonly IBasketballClubService _basketballClubService;

        public BasketballClubController(IBasketballClubService basketballClubService)
        {
            _basketballClubService = basketballClubService;
        }

        // get all
        [HttpGet]
        public async Task<ActionResult<List<BasketballClub>>> GetAllBasketballClubs()
        {
            var basketballClubs = await _basketballClubService.GetAllBasketballClubs();
            return Ok(basketballClubs);
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketballClub>> GetBasketballClub(int id)
        {
            var basketballClub = await _basketballClubService.GetBasketballClub(id);

            if(basketballClub == null)
            {
                return NotFound();
            }

            return Ok(basketballClub);
        }

        // post create
        [HttpPost]
        public async Task<ActionResult<BasketballClub>> CreateBasketballClub(BasketballClub basketballClub)
        {
            await _basketballClubService.CreateBasketballClub(basketballClub);

            return CreatedAtAction(nameof(GetBasketballClub), new { id = basketballClub.Id}, basketballClub);
        }
    }
}
