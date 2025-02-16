using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
