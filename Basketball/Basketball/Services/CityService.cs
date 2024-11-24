using Basketball.Models;

namespace Basketball.Services
{
    public class CityService : ICityService
    {
        private static readonly List<City> AllCities = new List<City>
        {
            new City { Id = 1, Name = "Los Angeles", CountryId = 1 },
            new City { Id = 2, Name = "San Francisco", CountryId = 1 },
            new City { Id = 3, Name = "Chicago", CountryId = 1 },
            new City { Id = 4, Name = "Miami", CountryId = 1 }
        };

        // get all
        public Task<List<City>> GetAllCities()
        {
            return Task.FromResult(AllCities);
        }

        // get by id
        public Task<City> GetCity(int id)
        {
            return Task.FromResult(AllCities.FirstOrDefault(x => x.Id == id));
        }

        // create city data
        public Task CreateCity(City city)
        {
            AllCities.Add(city);
            return Task.CompletedTask;
        }
    }
}
