using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers.Api
{
    [ApiController]
    [Route("api/add-item")]
    public class AddItemApiController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public AddItemApiController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add([FromBody] ShopItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _context.Categories
                .FirstOrDefault(c => c.Id == item.IdCategory);

            if (category == null)
                return BadRequest("Category not found");

            _context.ShopItems.Add(item);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                message = "محصول با موفقیت ذخیره شد",
                item
            });
        }
    }
}

