using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class UserController : Controller
    {
        
        
        public IActionResult RegesterHandle()
        {
           string name = Request.Form["name"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string resetpassword = Request.Form["resetpassword"];


            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", password);
            HttpContext.Session.SetString("ResetPassword", resetpassword);


            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginHandle()
        {

            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string rem = Request.Form["Remember"];
            if(email == HttpContext.Session.GetString("Email") && password == HttpContext.Session.GetString("Password"))
            {
                if (rem != null)
                {
                    CookieOptions obj = new CookieOptions();
                    obj.Expires = DateTime.Now.AddDays(7);
                    //store
                    Response.Cookies.Append("userInfo", email, obj);
                }
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("password", password);
                return RedirectToAction("Index","Home");
            }
            else
            {
                
                return RedirectToAction("Login");
            }


        }

        public IActionResult Logout()
        {


         
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Home");

            
        }



        public IActionResult Regester()
        {
            return View();
        }
        public IActionResult Profile()
        {
            ViewData["name"] = HttpContext.Session.GetString("Name");
            ViewData["email"] = HttpContext.Session.GetString("Email");
            return View();
        }

       


    }
}
