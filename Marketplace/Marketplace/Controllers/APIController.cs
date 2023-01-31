using Marketplace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Marketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        /*
        [HttpGet]
        public IActionResult Get()
        {
            {
                using (AppDbContext db = new AppDbContext())
                {
                    yield return new OkObjectResult(db.userAccount.ToList());
                }
            }
        }
        */


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            using (AppDbContext db = new AppDbContext()) 
            {
                if(db.userAccount.Single(u => u.UserID == (int)id) == null)
                {
                    return NotFound();
                }

            }

            {
                using (AppDbContext db = new AppDbContext())
                {
                    return new OkObjectResult(db.userAccount.Single(u => u.UserID == (int)id));
                }
            }
        }
        /*
        [HttpPost]
        public ActionResult<UserAccount> Add([FromBody] UserAccount acc)
        {

            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.userAccount.Add(acc);
                    db.SaveChanges();


                }
                ModelState.Clear();
                return Created($"/api/API/{acc.UserID}", acc);
            }

            return BadRequest();

        }

        [HttpDelete]
        //[Route("{id}")]
        public IActionResult Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var user = db.userAccount.Single(u => u.UserID == id);

                if (user == null)
                {
                    return NotFound();
                }

                db.userAccount.Remove(user);
                db.SaveChanges();
            }
            ModelState.Clear();
            

            return Ok();
        }

        
        [HttpPut]
        public UserAccount Put([FromBody] UserAccount user, string passwd)
        {
            using (AppDbContext db = new AppDbContext())
            {
                UserAccount user2 = db.userAccount.Single(u => u.UserID == user.UserID);
                user2.Password = passwd;
                db.SaveChanges();
            }
            ModelState.Clear();


            return user;
        }
        

        */

        /*
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            // else {
            /*
            if (id > 5)
            {
                return NotFound();
            }
            */

        //return new OkObjectResult(new UserAccount() { UserID = 1, Userame = "test", Email = "testEmail", FirstName = "testName", Address = "TestAdress", PhoneNumber = "45678", Password = "test", ConfirmPassword = "test", LastName = "test" });
        //return new UserAccount() { UserID = 8, Userame = "8test", Email = "8testEmail", FirstName = "testName", Address = "TestAdress", PhoneNumber = "45678", Password = "test", ConfirmPassword = "test", LastName = "test" };
        //}






    }
}
