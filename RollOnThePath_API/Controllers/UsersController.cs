using Microsoft.AspNetCore.Mvc;

namespace RollOnThePath_API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
