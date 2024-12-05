using Basketball.Data;
using Basketball.Models;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services
{
    public class CityDatabaseService : ICityService
    {
        private readonly BasketballDbContext _context;

        public CityDatabaseService(BasketballDbContext context)
        {
            _context = context;
        }

        // get all
        public async Task<List<City>> GetAllCities()
        {
            return await _context.Cities.Include(c => c.Country).ToListAsync();
        }

        // get by id
        public async Task<City> GetCity(int id)
        {
            return await _context.Cities.Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == id);
        }

        // create
        public async Task CreateCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        // update
        public async Task<City?> UpdateCity(int id, City city)
        {
            var existing = await _context.Cities.FindAsync(id);
            if (existing == null) return null;

            existing.Name = city.Name;
            existing.CountryId = city.CountryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        // delete
        public async Task DeleteCity(int id)
        {
            var existing = await _context.Cities.FindAsync(id);
            if (existing != null)
            {
                _context.Cities.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
