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

        // update
        public Task<City?> UpdateCity(int id, City city)
        {
            var c = AllCities.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                c.Name = city.Name;
                c.CountryId = city.CountryId;
            }
            return Task.FromResult(c);
        }

        // delete
        public Task DeleteCity(int id)
        {
            var c = AllCities.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                AllCities.Remove(c);
            }

            return Task.CompletedTask;
        }
    }
}
