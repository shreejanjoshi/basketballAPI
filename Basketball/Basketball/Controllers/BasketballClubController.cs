using Microsoft.AspNetCore.Mvc;

namespace Basketball.Controllers
{
    public class BasketballClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
