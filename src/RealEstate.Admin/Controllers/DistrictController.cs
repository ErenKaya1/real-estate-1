using System;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.Province;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Admin.Controllers
{
    public class DistrictController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(ProvinceEditViewModel model)
        {
            var entity = new District
            {
                DistrictNameTR = model.DistrictNameTR,
                DistrictNameEN = model.DistrictNameEN,
                CreatedDate = DateTime.Now.Date,
                ProvinceId = model.Id
            };

            return View();
        }
    }
}