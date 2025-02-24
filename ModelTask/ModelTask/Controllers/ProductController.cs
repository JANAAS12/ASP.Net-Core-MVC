using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelTask.Models;

namespace ModelTask.Controllers
{
    public class ProductController : Controller
    {

        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int Id)
        {

            var product = _context.Products.Find(Id);

            return View(product);

        }


        public IActionResult Update(int Id)
        {

            var product = _context.Products.Find(Id);

            return View(product);

        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }



        public IActionResult Delete(int Id)
        {
            var product = _context.Products.Find(Id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }




    }
}
