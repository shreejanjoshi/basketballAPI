using Basketball.Data;
using Basketball.Models;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Services
{
    public class BasketballClubDatabaseService : IBasketballClubService
    {
        private readonly BasketballDbContext _context;

        public BasketballClubDatabaseService(BasketballDbContext context)
        {
            _context = context;
        }

        // get all
        public async Task<List<BasketballClub>> GetAllBasketballClubs()
        {
            //return await _context.BasketballClubs.Include(bc => bc.City.BasketballClubs).ToListAsync();
            return await _context.BasketballClubs
                .Include(bc => bc.City)
                .ThenInclude(c => c.Country)
                .ToListAsync();
        }

        // get by id
        public async Task<BasketballClub> GetBasketballClub(int id)
        {
            return await _context.BasketballClubs
                .Include(bc => bc.City)
                .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(bc => bc.Id == id);
        }

        // create
        public async Task CreateBasketballClub(BasketballClub basketballClub)
        {
            _context.BasketballClubs.Add(basketballClub);
            await _context.SaveChangesAsync();
        }

        // update
        public async Task<BasketballClub?> UpdateBasketballClub(int id, BasketballClub basketballClub)
        {
            var existing = await _context.BasketballClubs.FindAsync(id);
            if (existing == null) return null;

            existing.Name = basketballClub.Name;
            existing.CityId = basketballClub.CityId;

            await _context.SaveChangesAsync();
            return existing;
        }

        // delete
        public async Task DeleteBasketballClub(int id)
        {
            var existing = await _context.BasketballClubs.FindAsync(id);
            if (existing != null)
            {
                _context.BasketballClubs.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
