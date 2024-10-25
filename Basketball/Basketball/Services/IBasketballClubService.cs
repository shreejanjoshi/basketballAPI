using Basketball.Models;

namespace Basketball.Services
{
    public interface IBasketballClubService
    {
        Task<List<BasketballClub>> GetAllBasketballClubs();
        Task<BasketballClub> GetBasketballClub(int id);
    }
}
