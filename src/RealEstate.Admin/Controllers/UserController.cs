using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}