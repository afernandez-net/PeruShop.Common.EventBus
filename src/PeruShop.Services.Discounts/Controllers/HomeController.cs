using Microsoft.AspNetCore.Mvc;

namespace PeruShop.Services.Discounts.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("PeruShop Discounts Service");
    }
}