using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.InteriorProperty;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewInterior(InteriorPropertyNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new InteriorProperty
            {
                PropertyNameTR = model.PropertyNameTR,
                PropertyNameEN = model.PropertyNameEN,
                CreatedTime = DateTime.Now.Date
            };

            var result = await _interiorPropertyService.AddOne(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("ListInteriors");
            }

            ViewData["NewInteriorError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }
    }
}