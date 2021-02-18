using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.ExternalProperty;
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
        private readonly IExternalPropertyService _externalPropertyService;

        public PropertyController(IInteriorPropertyService interiorPropertyService, IExternalPropertyService externalPropertyService)
        {
            _interiorPropertyService = interiorPropertyService;
            _externalPropertyService = externalPropertyService;
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

            var result = await _interiorPropertyService.AddOneAsync(entity);
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

            var entity = await _interiorPropertyService.GetByIdAsync(Convert.ToInt32(propertyId));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInterior(InteriorPropertyEditViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(EditInterior), new { propertyId = model.Id });

            var entity = await _interiorPropertyService.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity.PropertyNameTR = model.PropertyNameTR;
                entity.PropertyNameEN = model.PropertyNameEN;

                var result = await _interiorPropertyService.EditAsync(entity);
                if (result)
                {
                    TempData["EditInteriorMessage"] = Messages.EDIT_SUCCESSFULLY_MESSAGE;
                    return RedirectToAction(nameof(EditInterior), new { propertyId = model.Id });
                }
            }

            TempData["InteriorNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(ListInteriors));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInterior(int? propertyId)
        {
            if (propertyId == null)
            {
                TempData["InteriorNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(ListInteriors));
            }

            var result = await _interiorPropertyService.DeleteByIdAsync(Convert.ToInt32(propertyId));
            if (result)
            {
                TempData["DeleteInteriorMessage"] = Messages.DELETED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(ListInteriors));
            }

            TempData["DeleteInteriorError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction(nameof(ListInteriors));
        }

        [HttpGet]
        public IActionResult NewExternal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewExternal(ExternalPropertyNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new ExternalProperty
            {
                PropertyNameTR = model.PropertyNameTR,
                PropertyNameEN = model.PropertyNameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _externalPropertyService.AddOneAsync(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(ListExternals));
            }

            ViewData["NewExternalError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListExternals()
        {
            var models = await _externalPropertyService.GetAll().Select(x => new ExternalPropertyListViewModel
            {
                Id = x.Id,
                PropertyNameTR = x.PropertyNameTR,
                PropertyNameEN = x.PropertyNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> EditExternal(int? propertyId)
        {
            if (propertyId == null)
            {
                TempData["ExternalNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(ListExternals));
            }

            var entity = await _externalPropertyService.GetByIdAsync(Convert.ToInt32(propertyId));
            if (entity != null)
            {
                var model = new ExternalPropertyEditViewModel
                {
                    Id = entity.Id,
                    PropertyNameTR = entity.PropertyNameTR,
                    PropertyNameEN = entity.PropertyNameEN
                };

                return View(model);
            }

            TempData["ExternalNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(ListExternals));
        }
    }
}