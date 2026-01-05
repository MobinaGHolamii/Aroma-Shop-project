using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestApiController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Swagger works";
        }
    }
}
