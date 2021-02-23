using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.WarmingWay;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    public class WarmingWayController : Controller
    {
        private readonly IWarmingWayService _warmingWayService;

        public WarmingWayController(IWarmingWayService warmingWayService)
        {
            _warmingWayService = warmingWayService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(WarmingWayNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new WarmingWay
            {
                WarmingWayNameTR = model.WarmingWayNameTR,
                WarmingWayNameEN = model.WarmingWayNameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _warmingWayService.AddOneAsync(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("List");
            }

            ViewData["NewWarmingWayError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }
    }
}