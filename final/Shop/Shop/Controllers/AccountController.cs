using Microsoft.AspNetCore.Mvc;
using Shop.Data;


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
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == userName && u.Password == password && u.IsActive);

            if (user == null)
            {
                ViewBag.Error = "اطلاعات ورود اشتباه است";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
