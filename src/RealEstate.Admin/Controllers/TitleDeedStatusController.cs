using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.TitleDeedStatus;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
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
            if (result == SaveResult.Success)
            {
                TempData["SavedSuccessfully"] = Messages.SAVED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? titleDeedStatusId)
        {
            if (titleDeedStatusId == null)
            {
                TempData["TitleDeedStatusNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var entity = await _titleDeedStatusService.GetByIdAsync(Convert.ToInt32(titleDeedStatusId));
            if (entity != null)
            {
                var model = new TitleDeedStatusEditViewModel
                {
                    Id = entity.Id,
                    StatusNameTR = entity.StatusNameTR,
                    StatusNameEN = entity.StatusNameEN
                };

                return View(model);
            }

            TempData["TitleDeedStatusNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TitleDeedStatusEditViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Edit), new { titleDeedStatusId = model.Id });

            var entity = await _titleDeedStatusService.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity.StatusNameTR = model.StatusNameTR;
                entity.StatusNameEN = model.StatusNameEN;

                var result = await _titleDeedStatusService.EditAsync(entity);
                if (result == SaveResult.Success)
                {
                    TempData["EditTitleDeedStatusMessage"] = Messages.EDIT_SUCCESSFULLY_MESSAGE;
                    return RedirectToAction(nameof(Edit), new { titleDeedStatusId = model.Id });
                }
            }

            TempData["TitleDeedStatusNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? titleDeedStatusId)
        {
            if (titleDeedStatusId == null)
            {
                TempData["TitleDeedStatusNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var result = await _titleDeedStatusService.DeleteByIdAsync(Convert.ToInt32(titleDeedStatusId));
            if (result == SaveResult.Success)
            {
                TempData["DeleteTitleDeedStatusMessage"] = Messages.DELETED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
            }
            else if (result == SaveResult.InUse)
            {
                TempData["TitleDeedStatusInUseError"] = Messages.TITLE_DEED_STATUS_DELETE_ERROR;
                return RedirectToAction(nameof(List));
            }

            TempData["DeleteTitleDeedStatusError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction(nameof(List));
        }
    }
}