using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    public class BuildingTypeController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}