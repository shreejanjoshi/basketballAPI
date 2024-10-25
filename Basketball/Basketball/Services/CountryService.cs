using Basketball.Models;

namespace Basketball.Services
{
    public class CountryService : ICountryService
    {
        private static readonly List<Country> AllCountries = new List<Country>
        {
            new Country { Id = 1, Name = "United States" }
        };

        // get all
        public Task<List<Country>> GetAllCountries()
        {
            return Task.FromResult(AllCountries);
        }

        // get by id
        public Task<Country> GetCountry(int id)
        {
            return Task.FromResult(AllCountries.FirstOrDefault(x => x.Id == id));
        }
    }
}
