using e_commerceTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace e_commerceTask.Controllers
{
    public class UsersController : Controller
    {


        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {

            _context = context;
        
        
        }
        public IActionResult Index()
        {

            var allUsers = _context.Products.ToList();

            return View(allUsers);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {

                user.Role = "user";
                _context.Users.Add(user);
                _context.SaveChanges();
              
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("password", user.Password);
                HttpContext.Session.SetString("role", user.Role);

                return RedirectToAction("Login");
            }
            return View(user);
        }



        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {


            if (ModelState.IsValid)
            {
                var userInfo = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (user != null&& userInfo.Role == "user")
                {
                    return RedirectToAction("Index", "Users");
                    

                }
                else 
                {
                    return RedirectToAction("Index","Admins");

                }
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("password", user.Password);
                HttpContext.Session.SetString("role", user.Role);
            }
            else
            {
                return View(user);

            }



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
