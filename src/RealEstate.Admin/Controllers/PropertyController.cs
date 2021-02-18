using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                return RedirectToAction(nameof(ListInteriors));
            }

            ViewData["NewInteriorError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListInteriors()
        {
            var models = await _interiorPropertyService.GetAll().Select(x => new InteriorPropertyListViewModel
            {
                Id = x.Id,
                PropertyNameTR = x.PropertyNameTR,
                PropertyNameEN = x.PropertyNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> EditInterior(int? propertyId)
        {
            if (propertyId == null)
            {
                TempData["InteriorNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(ListInteriors));
            }

            var entity = await _interiorPropertyService.GetById(Convert.ToInt32(propertyId));
            if (entity != null)
            {
                var model = new InteriorPropertyEditViewModel
                {
                    Id = entity.Id,
                    PropertyNameTR = entity.PropertyNameTR,
                    PropertyNameEN = entity.PropertyNameEN
                };

                return View(model);
            }

            TempData["InteriorNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(ListInteriors));
        }
    }
}