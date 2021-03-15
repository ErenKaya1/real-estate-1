using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.BuildingType;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
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
            if (result == SaveResult.Success)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BuildingTypeEditViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Edit), new { buildingTypeId = model.Id });

            var entity = await _buildingTypeService.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity.BuildingTypeNameTR = model.BuildingTypeNameTR;
                entity.BuildingTypeNameEN = model.BuildingTypeNameEN;

                var result = await _buildingTypeService.EditAsync(entity);
                if (result == SaveResult.Success)
                {
                    TempData["EditBuildingTypeMessage"] = Messages.EDIT_SUCCESSFULLY_MESSAGE;
                    return RedirectToAction(nameof(Edit), new { buildingTypeId = model.Id });
                }
            }

            TempData["BuildingTypeNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? buildingTypeId)
        {
            if (buildingTypeId == null)
            {
                TempData["BuildingTypeNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var result = await _buildingTypeService.DeleteByIdAsync(Convert.ToInt32(buildingTypeId));
            if (result == SaveResult.Success)
            {
                TempData["DeleteBuildingTypeMessage"] = Messages.DELETED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
            }
            else if (result == SaveResult.InUse)
            {
                TempData["BuildingTypeInUseError"] = Messages.BUILDING_TYPE_DELETE_ERROR;
                return RedirectToAction(nameof(List));
            }

            TempData["DeleteBuildingTypeError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction(nameof(List));
        }
    }
}