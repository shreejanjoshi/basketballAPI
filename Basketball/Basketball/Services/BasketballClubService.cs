using Basketball.Models;

namespace Basketball.Services
{
    public class BasketballClubService : IBasketballClubService
    {
        private static readonly List<BasketballClub> AllBasketballClubs = new List<BasketballClub>
        {
            new BasketballClub { Id = 1, Name = "Los Angeles Lakers", CityId = 1 },
            new BasketballClub { Id = 2, Name = "Golden State Warriors", CityId = 2 },
            new BasketballClub { Id = 3, Name = "Chicago Bulls", CityId = 3 },
            new BasketballClub { Id = 4, Name = "Miami Heat", CityId = 4 }
        };

        // get all
        public Task<List<BasketballClub>> GetAllBasketballClubs()
        {
            return Task.FromResult(AllBasketballClubs);
        }

        // get by id
        public Task<BasketballClub> GetBasketballClub(int id)
        {
            return Task.FromResult(AllBasketballClubs.FirstOrDefault(x => x.Id == id));
        }
    }
}
