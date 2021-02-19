using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
    }
}