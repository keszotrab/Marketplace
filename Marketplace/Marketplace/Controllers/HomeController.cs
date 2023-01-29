using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Marketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Search(string prodSearch)
        {
            using (AppDbContext db = new AppDbContext()) 
            { 

                ViewData["GetProdDetails"] = prodSearch;
                var prodQuery = from x in db.product select x;
                if (!String.IsNullOrEmpty(prodSearch))
                {
                    prodQuery = prodQuery.Where(x => x.Name.Contains(prodSearch) || x.Descryption.Contains(prodSearch));
                }
                return View( prodQuery.AsNoTracking().ToList());
                //await

                return View();    
            }
        }






























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}