using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelTask.Models;

namespace ModelTask.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _context;
        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Index()
        {
            var deptList = _context.Departments.ToList();
            return View(deptList);
        }



    }
}
