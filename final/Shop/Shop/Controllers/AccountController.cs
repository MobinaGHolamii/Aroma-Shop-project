using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopDbContext _context;

        public AccountController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login"); 
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == userName
                                  && u.Password == password
                                  && u.IsActive);

            if (user == null)
            {
                ViewBag.Error = "نام کاربری یا رمز اشتباه است";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetInt32("Role", user.FkRole);
            HttpContext.Session.SetString("UserName", user.UserName);

            if (user.FkRole == 1) 
                return RedirectToAction("NewItem", "AddItem");
            else 
                return RedirectToAction("Index", "Home");
        }
    }
}
