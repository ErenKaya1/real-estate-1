using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.TitleDeedStatus;
using src.RealEstate.Common.Constants;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class TitleDeedStatusController : Controller
    {
        private readonly ITitleDeedStatusService _titleDeedStatusService;

        public TitleDeedStatusController(ITitleDeedStatusService titleDeedStatusService)
        {
            _titleDeedStatusService = titleDeedStatusService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(TitleDeedStatusNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new TitleDeedStatus
            {
                StatusNameTR = model.StatusNameTR,
                StatusNameEN = model.StatusNameEN,
                CreatedDate = DateTime.Now.Date
            };

            var result = await _titleDeedStatusService.AddOneAsync(entity);
            if (result)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction("List");
            }

            ViewData["NewTitleDeedStatusError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var models = await _titleDeedStatusService.GetAll().Select(x => new TitleDeedStatusListViewModel
            {
                Id = x.Id,
                StatusNameTR = x.StatusNameTR,
                StatusNameEN = x.StatusNameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }
    }
}