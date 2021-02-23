using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class EstateController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}