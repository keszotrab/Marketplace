using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;
using Microsoft.AspNetCore.Http;

namespace Marketplace.Controllers
{
    public class AccountController : Controller
    {
        /*
        public IActionResult Index()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return View(db.userAccount.ToList());
            }
                
        }
        */

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                { 
                    db.userAccount.Add(account);
                    db.SaveChanges();

                
                }
                ModelState.Clear();
                ViewBag.Message = "Your account has been successfully created "+account.FirstName+". You can now login to your account!";
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserAccount user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var usr = db.userAccount.Single(u => u.Userame == user.Userame && u.Password == user.Password);
                if (usr != null)
                {
                    

                    HttpContext.Session.SetString("UserID", usr.UserID.ToString());
                    HttpContext.Session.SetString("Username", usr.Userame.ToString());
                    HttpContext.Session.SetInt32("Logged", 1);


                    return RedirectToAction("Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        public IActionResult Profile()
        {

            if (HttpContext.Session.Get("UserID") != null)
            {
                return View();
            }
            else { 
            return RedirectToAction("Login");
            }
        }

        public IActionResult MyProducts()
        {
            return View();
        }

        public IActionResult BoughtProducts()
        {
            return View();
        }

        public IActionResult SoldProducts()
        {
            return View();
        }





    }

}
