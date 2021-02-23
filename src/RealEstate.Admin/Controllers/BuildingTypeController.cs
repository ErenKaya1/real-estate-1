using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("List");
            }

            TempData["NewBuildingTypeError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }
    }
}