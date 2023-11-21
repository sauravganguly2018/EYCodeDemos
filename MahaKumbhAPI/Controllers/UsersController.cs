using Microsoft.AspNetCore.Mvc;
using MahaKumbhAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MahaKumbhAPI.Models;
using MahaKumbhAPI.Models.Data;

namespace MahaKumbhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly MahaKumbhAPIDBContext db;
        public UsersController(MahaKumbhAPIDBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = db.Users.ToList();
            if (users.IsNullOrEmpty())
            {
                return NotFound($"No Users Found");
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = db.Users.Find(id);
            if (user==null)
            {
                return NotFound($"user not found with id : {id}");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email is already in use.");
                return BadRequest(ModelState);
            }
            user.Password= BCrypt.Net.BCrypt.HashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isValidUser = db.Users.ToList().FirstOrDefault(u => u.Email == loginUser.Email && BCrypt.Net.BCrypt.Verify(loginUser.Password, u.Password));

            if (isValidUser != null)
            {
                return Ok(new { Message = "Login Successful" });
            }
            else
            {
                return Unauthorized(new { Message = "Login Unsuccessful" });
            }
        }
    }
}
