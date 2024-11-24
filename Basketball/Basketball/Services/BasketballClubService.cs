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

        // create basketball club data
        public Task CreateBasketballClub(BasketballClub basketballClub)
        {
            AllBasketballClubs.Add(basketballClub);
            return Task.CompletedTask;
        }

        // update 
        public Task<BasketballClub?> UpdateBasketballClub(int id, BasketballClub basketballClub)
        {
            var c = AllBasketballClubs.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                c.Name = basketballClub.Name;
                c.CityId = basketballClub.CityId;
            }
            return Task.FromResult(c);
        }

        // delete
        public Task DeleteBasketballClub(int id)
        {
            var c = AllBasketballClubs.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                AllBasketballClubs.Remove(c);
            }

            return Task.CompletedTask;
        }
    }
}
