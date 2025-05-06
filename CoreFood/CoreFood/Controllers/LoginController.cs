using CoreFood.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace CoreFood.Controllers
{
    public class LoginController : Controller
    {

        Context c = new Context();
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
         
            var dataValue = c.Admins.FirstOrDefault(x=>x.userName == admin.userName && x.password == admin.password);
            if (dataValue != null) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.userName)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index", "Category");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        
    }
}
