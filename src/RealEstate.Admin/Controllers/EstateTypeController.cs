using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    public class EstateTypeController : Controller
    {
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
    }
}