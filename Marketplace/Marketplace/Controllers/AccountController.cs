using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

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
            account.Rank = "user";
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                { 
                    db.userAccount.Add(account);
                    db.SaveChanges();

                
                }
                ModelState.Clear();
                ViewBag.Message = "Your account has been successfully created "+account.FirstName+". You can now login to your account!";
                                                                                                                                                 //add vldin
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
                    

                    HttpContext.Session.SetInt32("UserID", usr.UserID);
                    HttpContext.Session.SetString("Username", usr.Userame.ToString());
                    HttpContext.Session.SetInt32("Logged", 1);
                    HttpContext.Session.SetString("Rank", usr.Rank);

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


        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (stillLogged())
            {
                product.sellerId = (int)HttpContext.Session.GetInt32("UserID");

                if (ModelState.IsValid)
                {
                    using (AppDbContext db = new AppDbContext())
                    {
                        db.product.Add(product);
                        db.SaveChanges();

                    }
                    ModelState.Clear();
                    ViewBag.Message = "Your have successfully added product" + product.Name + "!";
                    //add vldin or not idk
                }
                return View();



            }
            

            return View();
        }


        public bool stillLogged()
        {
            if (HttpContext.Session.GetInt32("Logged") == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
