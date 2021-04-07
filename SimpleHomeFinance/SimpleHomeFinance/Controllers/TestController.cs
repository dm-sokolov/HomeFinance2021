using Microsoft.AspNetCore.Mvc;

namespace SimpleHomeFinance.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new {name = "Dmitriy"});
        }
    }
}
