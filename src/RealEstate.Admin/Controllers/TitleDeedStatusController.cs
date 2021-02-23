using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class TitleDeedStatusController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}