using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models; 

namespace Shop.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly ShopDbContext _context;

        public CreateAccountController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string userName, string email, string password)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(userName))
                errors.Add("نام کاربری الزامی است.");

            if (string.IsNullOrWhiteSpace(email))
                errors.Add("ایمیل الزامی است.");

            if (string.IsNullOrWhiteSpace(password))
                errors.Add("رمز عبور الزامی است.");

            if (_context.Users.Any(u => u.UserName == userName))
                errors.Add("این نام کاربری قبلاً استفاده شده.");

            if (errors.Any())
                return Json(new { success = false, errors });

            var user = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                FkRole = 2, 
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                message = "اکانت شما با موفقیت ایجاد شد!",
                userId = user.Id,
                userName = user.UserName,
                role = user.FkRole
            });
        }

    }
}

