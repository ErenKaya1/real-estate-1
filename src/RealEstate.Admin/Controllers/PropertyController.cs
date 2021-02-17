using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        private readonly IInteriorPropertyService _interiorPropertyService;

        public PropertyController(IInteriorPropertyService interiorPropertyService)
        {
            _interiorPropertyService = interiorPropertyService;
        }

        [HttpGet]
        public IActionResult NewInterior()
        {
            return View();
        }
    }
}