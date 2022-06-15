using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UdemyProject.DataAccess;
using UdemyProject.Models;

namespace UdemyProject.Areas.Customer.Controllers
{
    public class Authorization : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public Authorization(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Index(User user)
        {
            var userfromdb = _dbcontext.Users.FirstOrDefault(u => u.Login == user.Login);
            if (userfromdb is not null && userfromdb.Password.Equals(user.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userfromdb.Login),
                    new Claim(ClaimTypes.Role, userfromdb.Role)
                };

                var identity = new ClaimsIdentity(claims, "login");

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                Response.Cookies.Delete("MyCookie");
                Response.Cookies.Append("MyCookie", userfromdb.Role);
                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }

            return View();
        }
        
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Users.Add(obj);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    
    }

}
