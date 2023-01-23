﻿using Microsoft.AspNetCore.Mvc;
using Marketplace.Models;
using Microsoft.AspNetCore.Http;

namespace Marketplace.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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



                    //HttpContext.Session.SetString("UserID", usr.UserID.ToString());
                    //HttpContext.Session.SetString(usr.Userame.ToString(), "Username");


                    //HttpContext.Session["UserID"] = usr.UserID.ToString();
                    //context.Session["Test key"] = "Test value";

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }

        public IActionResult LoggedIn()
        {

            if (HttpContext.Session.Get("UserID") != null)
            {
                
            }

            return View();
        }

    }
}