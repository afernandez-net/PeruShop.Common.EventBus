namespace PeruShop.Services.Customers.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("PeruShop Customers Service");
    }
}