using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using NuGet.Packaging.Signing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

                    var exists = db.userAccount.Where(u => u.Userame == account.Userame);
                    int asd = exists.Count();

                    if (asd > 0)
                    {
                        ViewBag.Message = "Account with this username already exists!";
                        return View();
                    }
                    else 
                    {
                        db.userAccount.Add(account);
                        db.SaveChanges();

                        ModelState.Clear();
                        ViewBag.Message = "Your account has been successfully created " + account.FirstName + ". You can now login to your account!";

                        return View();
                    }

                }
                
                //add vldin
            }

            ViewBag.Message = "Something went wrong, account wasn't created.";
            return View();
        }



        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();


            return View("Login");
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


        //[HttpGet]
        public IActionResult MyProducts()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return View(db.product.ToList());
            }
        }

        [Route("Account/MyProducts/Details/{id}")]
        public IActionResult Details(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var prod = db.product.Single(p => p.Id == id);

                return View(prod);
            }
        }


        [HttpPost]
        [Route("Account/MyProducts/Edit/{id}")]
        public IActionResult Edit(int id, Product product)
        {
            if (product.sellerId == HttpContext.Session.GetInt32("UserID"))
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Product prod = db.product.Single(p => p.Id == 1);
                    prod.Name = product.Name;
                    prod.Descryption = product.Descryption;
                    prod.Price = product.Price;
                    prod.CategoryId = product.CategoryId;
                    db.SaveChanges();

                }
                ModelState.Clear();

                ViewBag.Message = "Your have successfully edited your item!";
                return View("Profile");
                //return View("Details",  product.Id);
            }
            else
            {
                ViewBag.MessageNotLogged = "You can't edit without being logged in!";
                return View("Login");
            }
        }

        [Route("Account/MyProducts/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var prod = db.product.Single(p => p.Id == id);

                return View(prod);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (stillLogged())
            {
                product.Img = null;
                product.sellerId = (int)HttpContext.Session.GetInt32("UserID"); ;

                if (ModelState.IsValid)
                {
                    using (AppDbContext db = new AppDbContext())
                    {

                        var usr = db.userAccount.Single(u => u.UserID == HttpContext.Session.GetInt32("UserID"));
                        product.sellerId = usr.UserID;

                        db.product.Add(product);
                        db.SaveChanges();

                    }
                    ModelState.Clear();
                    ViewBag.Message = "Your account has been successfully created " +  ". You can now login to your account!";
                    //add vldin
                }
            }

            ViewBag.MessageNotLogged = "You can't add products without being logged in!";
            return View("Login");
        }



        [Route("Account/MyProducts/Buy/{id}")]
        public IActionResult Buy(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                
                var prod = db.product.Single(p => p.Id == id);
                HttpContext.Session.SetInt32("buyProdId", id);

                return View();
            }
        }


        [HttpPost]
        [Route("Account/MyProducts/Buy/{id}")]
        public IActionResult Buy(Transaction transaction)
        {
            if (stillLogged())
            {


                using (AppDbContext db = new AppDbContext())
                {
                    var prod = db.product.Single(p => p.Id == (int)HttpContext.Session.GetInt32("buyProdId"));

                    transaction.productId = (int)HttpContext.Session.GetInt32("buyProdId");
                    transaction.buyerId = (int)HttpContext.Session.GetInt32("UserID");
                    transaction.price = prod.Price + transaction.count;

                    transaction.productId = (int)HttpContext.Session.GetInt32("buyProdId");
                    transaction.buyerId = (int)HttpContext.Session.GetInt32("UserID");
                    transaction.price = prod.Price + transaction.count;


                    db.transaction.Add(transaction);
                    db.SaveChanges();
                }

                return View("Profile");
            }
            else
            {
                return View("Login");
            }
        }


        [Route("Account/MyProducts/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var prod = db.product.Single(p => p.Id == id);

                return View(prod);
            }
        }



        [HttpPost, ActionName("Delete")]
        [Route("Account/MyProducts/Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var prod = db.product.Single(p => p.Id == id);



                if (prod.sellerId == HttpContext.Session.GetInt32("UserID"))
                {
                    db.product.Remove(prod);
                    db.SaveChanges();


                    ModelState.Clear();

                    ViewBag.Message = "Your have successfully deleted your item!";
                    return View("Profile");

                }
                else
                {
                    ViewBag.MessageNotLogged = "You can't delete without being logged in!";
                    return View("Login");
                }


            }
        }




        public IActionResult BoughtProducts()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return View(db.transaction.ToList());
            }
        }
        
        public IActionResult SoldProducts()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return View(db.transaction.ToList());
            }
        }


        public IActionResult MakeAdmin()
        {
            ViewBag.RankMessage = null;
            return View();
        }


        [HttpPost]
        public IActionResult MakeAdmin(string username, string rank)
        {
            if (HttpContext.Session.GetString("Rank") == "Admin" && username != HttpContext.Session.GetString("Username"))
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var user = db.userAccount.Single(p => p.Userame == username);
                    user.Rank = rank;
                    db.SaveChanges();

                    ViewBag.RankMessage = "You have succesfully changed " + user.Userame + "'s rank to " + user.Rank + "!";
                    return View();
                }
            }
            else
            {
                return View("Error");
                //exception maybe?
            }
        }

        public IActionResult Error()
        {
            return View();
        }




        /*

        /////////////////////////////////////////////////////////////////////////
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

        */

        /////////////////////////////////////////////////////////////////////////
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
