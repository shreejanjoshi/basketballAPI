using Basketball.Models;

namespace Basketball.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCity(int id);
        Task CreateCity(City city);
        Task<City?> UpdateCity(int id, City city);
        Task DeleteCity(int id);
    }
}
