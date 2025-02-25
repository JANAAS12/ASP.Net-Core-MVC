using e_commerceTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerceTask.Controllers
{
    public class AdminsController : Controller
    {

        private readonly MyDbContext _context;

        public AdminsController(MyDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var usersList = _context.Users.ToList();
            return View(usersList);
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

        public IActionResult Update(int Id)
        {

            var user = _context.Users.Find(Id);

            return View(user);

        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }
      
        public IActionResult IndexProduct()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("IndexProduct");
        }


        public IActionResult DetailsProduct(int Id)
        {

            var product = _context.Products.Find(Id);

            return View(product);

        }


        public IActionResult UpdateProduct(int Id)
        {

            var product = _context.Products.Find(Id);

            return View(product);

        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("IndexProduct");


        }



        public IActionResult DeleteProduct(int Id)
        {
            var product = _context.Products.Find(Id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("IndexProduct");

        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
