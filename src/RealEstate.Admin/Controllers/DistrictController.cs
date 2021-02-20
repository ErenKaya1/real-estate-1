using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.District;
using src.RealEstate.Admin.Models.Province;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProvinceEditViewModel model)
        {
            var entity = new District
            {
                DistrictNameTR = model.DistrictNameTR,
                DistrictNameEN = model.DistrictNameEN,
                CreatedDate = DateTime.Now.Date,
                ProvinceId = model.Id
            };

            var result = await _districtService.AddAsync(entity);
            if (result)
            {
                TempData["NewDistrictMessage"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("Edit", "Province", new { provinceId = model.Id });
            }

            TempData["NewDistrictError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction("Edit", "Province", new { provinceId = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? provinceId, int? districtId)
        {
            if (provinceId == null || districtId == null)
            {
                TempData["DistrictNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
            }

            var entity = await _districtService.GetByIdAsync(Convert.ToInt32(provinceId), Convert.ToInt32(districtId));
            if (entity != null)
            {
                var model = new DistrictEditViewModel
                {
                    DistrictId = entity.Id,
                    DistrictNameTR = entity.DistrictNameTR,
                    DistrictNameEN = entity.DistrictNameEN,
                    ProvinceId = entity.ProvinceId
                };

                return View(model);
            }

            TempData["DistrictNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? provinceId, int? districtId)
        {
            if (provinceId == null || districtId == null)
            {
                TempData["DistrictNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
            }

            var result = await _districtService.DeleteByIdAsync(Convert.ToInt32(provinceId), Convert.ToInt32(districtId));
            if (result == DeleteResponse.Success)
            {
                TempData["DeleteDistrictMessage"] = Messages.DELETED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
            }
            else if (result == DeleteResponse.InUse)
            {
                TempData["DistrictInUseError"] = Messages.DISTRICT_DELETE_ERROR;
                return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
            }

            TempData["DeleteDistrictError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction("Edit", "Province", new { provinceId = provinceId });
        }
    }
}