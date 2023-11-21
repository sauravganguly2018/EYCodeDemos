using MahaKumbh.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using MahaKumbh.Models.Domain;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace MahaKumbh.Controllers
{
    public class UsersController : Controller
    {
        MahaKumbhDbContext db=new MahaKumbhDbContext();

     
        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            TempData["UserName"] = UserName;
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (db.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                return View(user);
            }
            user.Password=BCrypt.Net.BCrypt.HashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
            TempData["Registration"] = $"Username : {user.Email} is successfully Registered. You can Login now!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var isValidUser=db.Users.ToList().FirstOrDefault(u=> u.Email==user.Email && BCrypt.Net.BCrypt.Verify(user.Password, u.Password));
          
            if(isValidUser!=null)
                {
                    HttpContext.Session.SetString("UserName", $"{isValidUser.FirstName} {isValidUser.LastName}");
                    TempData["Login"] = $"{user.Email} is successfully logged in!";
                    return RedirectToAction("Index","Home");
                }
            TempData["Message"] = "Invalid Login Credentials";
            return RedirectToAction("Login","Users");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
