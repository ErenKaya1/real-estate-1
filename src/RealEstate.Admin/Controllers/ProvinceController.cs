using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.Province;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProvinceNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Province
            {
                NameTR = model.NameTR,
                NameEN = model.NameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _provinceService.AddOneAsync(entity);
            if (result) 
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("List");
            }

            ViewData["NewProvinceError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }
    }
}