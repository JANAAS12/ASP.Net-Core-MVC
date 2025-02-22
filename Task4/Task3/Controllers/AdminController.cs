using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

    }
}
