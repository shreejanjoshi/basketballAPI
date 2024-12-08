using Basketball.Models;

namespace Basketball.Services
{
    public class BasketballClubService : IBasketballClubService
    {
        // Mock data for Countries
        private static readonly List<Country> AllCountries = new List<Country>
        {
            new Country { Id = 1, Name = "United States" },
            new Country { Id = 2, Name = "Canada" }
        };

        // Mock data for Cities
        private static readonly List<City> AllCities = new List<City>
        {
            new City { Id = 1, Name = "Los Angeles", CountryId = 1, Country = AllCountries[0] },
            new City { Id = 2, Name = "San Francisco", CountryId = 1, Country = AllCountries[0] },
            new City { Id = 3, Name = "Toronto", CountryId = 2, Country = AllCountries[1] },
            new City { Id = 4, Name = "Vancouver", CountryId = 2, Country = AllCountries[1] }
        };

        // Mock data for BasketballClubs
        private static readonly List<BasketballClub> AllBasketballClubs = new List<BasketballClub>
        {
            new BasketballClub { Id = 1, Name = "Los Angeles Lakers", CityId = 1, City = AllCities[0] },
            new BasketballClub { Id = 2, Name = "Golden State Warriors", CityId = 2, City = AllCities[1] },
            new BasketballClub { Id = 3, Name = "Toronto Raptors", CityId = 3, City = AllCities[2] },
            new BasketballClub { Id = 4, Name = "Vancouver Grizzlies", CityId = 4, City = AllCities[3] }
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
