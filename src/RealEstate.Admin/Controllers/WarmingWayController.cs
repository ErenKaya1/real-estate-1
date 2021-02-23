using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                return RedirectToAction(nameof(List));
            }

            ViewData["NewWarmingWayError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var models = await _warmingWayService.GetAll().Select(x => new WarmingWayListViewModel
            {
                Id = x.Id,
                WarmingWayNameTR = x.WarmingWayNameTR,
                WarmingWayNameEN = x.WarmingWayNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? warmingWayId)
        {
            if (warmingWayId == null)
            {
                TempData["WarmingWayNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var entity = await _warmingWayService.GetByIdAsync(Convert.ToInt32(warmingWayId));
            if (entity != null)
            {
                var model = new WarmingWayEditViewModel
                {
                    Id = entity.Id,
                    WarmingWayNameTR = entity.WarmingWayNameTR,
                    WarmingWayNameEN = entity.WarmingWayNameEN
                };

                return View(model);
            }

            TempData["WarmingWayNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }
    }
}