using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    public class WarmingWayController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}