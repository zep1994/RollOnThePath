using Microsoft.AspNetCore.Mvc;

namespace RollOnThePath_API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
