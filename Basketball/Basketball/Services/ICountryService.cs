using Basketball.Models;

namespace Basketball.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountry(int id);
        Task CreateCountry(Country country);
        Task<Country?> UpdateCountry(int id, Country country);
        Task DeleteCountry(int id);
    }
}
