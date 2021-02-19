using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.EstateType;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    public class EstateTypeController : Controller
    {
        private readonly IEstateTypeService _estateTypeService;

        public EstateTypeController(IEstateTypeService estateTypeService)
        {
            _estateTypeService = estateTypeService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(EstateTypeNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new EstateType
            {
                TypeNameTR = model.TypeNameTR,
                TypeNameEN = model.TypeNameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _estateTypeService.AddOneAsync(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
            }

            ViewData["NewEstateTypeError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var models = await _estateTypeService.GetAll().Select(x => new EstateTypeListViewModel
            {
                Id = x.Id,
                TypeNameTR = x.TypeNameTR,
                TypeNameEN = x.TypeNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }
    }
}