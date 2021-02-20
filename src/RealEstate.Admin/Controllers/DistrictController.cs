using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.Province;
using src.RealEstate.Common.Constants;
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
    }
}