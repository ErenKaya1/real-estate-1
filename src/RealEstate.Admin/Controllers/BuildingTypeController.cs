using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.BuildingType;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class BuildingTypeController : Controller
    {
        private readonly IBuildingTypeService _buildingTypeService;

        public BuildingTypeController(IBuildingTypeService buildingTypeService)
        {
            _buildingTypeService = buildingTypeService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BuildingTypeNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new BuildingType
            {
                BuildingTypeNameTR = model.BuildingTypeNameTR,
                BuildingTypeNameEN = model.BuildingTypeNameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _buildingTypeService.AddOneAsync(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
            }

            ViewData["NewBuildingTypeError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var models = await _buildingTypeService.GetAll().Select(x => new BuildingTypeListViewModel
            {
                Id = x.Id,
                BuildingTypeNameTR = x.BuildingTypeNameTR,
                BuildingTypeNameEN = x.BuildingTypeNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? buildingTypeId)
        {
            if (buildingTypeId == null)
            {
                TempData["BuildingTypeNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var entity = await _buildingTypeService.GetByIdAsync(Convert.ToInt32(buildingTypeId));
            if (entity != null)
            {
                var model = new BuildingTypeEditViewModel
                {
                    Id = entity.Id,
                    BuildingTypeNameTR = entity.BuildingTypeNameTR,
                    BuildingTypeNameEN = entity.BuildingTypeNameEN
                };

                return View(model);
            }

            TempData["BuildingTypeNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }
    }
}