using Basketball.Models;

namespace Basketball.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCity(int id);
    }
}
