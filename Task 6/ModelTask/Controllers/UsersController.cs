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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var user = _context.Users.Find(id); // Fetch the user from the database
            if (user == null)
            {
                return NotFound(); // Return 404 if the user is not found
            }
            return View(user); // Pass the user to the view
        }
    }
}