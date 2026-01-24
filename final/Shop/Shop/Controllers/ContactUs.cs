using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    public class ContactUs : Controller
    {
        private readonly ShopDbContext _context;
        private readonly PermissionService _permissionService;

        public ContactUs(ShopDbContext context, PermissionService permissionService)
        {
            _context = context;
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewMessage(ContactMessage model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

          
            if (ModelState.IsValid)
            {
                _context.Message.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "پیام شما با موفقیت ارسال شد!";
                return RedirectToAction("NewMessage");
            }

            return View(model);
        }

        public IActionResult TestSave()
        {
         
            var msg = new ContactMessage
            {
                UserName = "TEST",
                Phone = "123",
                Email = "test@test.com",
                Message = "HELLO"
            };

            _context.Message.Add(msg);
            _context.SaveChanges();

            return Content("SAVED");
        }
    }
}

