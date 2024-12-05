using Basketball.Data;
using Basketball.Models;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services
{
    public class CountryDatabaseService : ICountryService
    {
        private readonly BasketballDbContext _context;

        public CountryDatabaseService(BasketballDbContext context)
        {
            _context = context;
        }

        // get all
        public async Task<List<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // get by id
        public async Task<Country> GetCountry(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        // create
        public async Task CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        // update
        public async Task<Country?> UpdateCountry(int id, Country country)
        {
            var existing = await _context.Countries.FindAsync(id);
            if (existing == null) return null;

            existing.Name = country.Name;

            await _context.SaveChangesAsync();
            return existing;
        }

        // delete
        public async Task DeleteCountry(int id)
        {
            var existing = await _context.Countries.FindAsync(id);
            if (existing != null)
            {
                _context.Countries.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
