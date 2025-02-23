using Microsoft.AspNetCore.Mvc;
using ModelTask.Models;
using System.Linq;

namespace ModelTask.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

      
        public IActionResult Index()
        {
            var usersList = _context.Users.ToList();
            return View(usersList);
        }
    }
}