using Microsoft.AspNetCore.Mvc;

namespace PetShop.Services.Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
