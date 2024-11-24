using Basketball.Models;
using Microsoft.Extensions.Hosting;

namespace Basketball.Services
{
    public interface IBasketballClubService
    {
        Task<List<BasketballClub>> GetAllBasketballClubs();
        Task<BasketballClub> GetBasketballClub(int id);
        Task CreateBasketballClub(BasketballClub basketballClub);
        Task<BasketballClub?> UpdateBasketballClub(int id, BasketballClub basketballClub);
        Task DeleteBasketballClub(int id);
    }
}
