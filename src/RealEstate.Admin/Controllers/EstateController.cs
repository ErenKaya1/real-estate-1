using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.Estate;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class EstateController : Controller
    {
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(EstateNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Estate
            {
                
            };

            var interiorProperties = model.CheckBoxes["InteriorProperties"].ToList();
            var externalProperties = model.CheckBoxes["ExternalProperties"].ToList();
            var ambitProperties = model.CheckBoxes["AmbitProperties"].ToList();
            var transportationProperties = model.CheckBoxes["TransportationProperties"].ToList();

            return View();
        }
    }
}