using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Admin.Models.District;
using src.RealEstate.Admin.Models.Province;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
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
                return RedirectToAction(nameof(List));
            }

            ViewData["NewProvinceError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var models = await _provinceService.GetAll().Select(x => new ProvinceListViewModel
            {
                Id = x.Id,
                NameTR = x.NameTR,
                NameEN = x.NameEN
            }).AsNoTracking().ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? provinceId)
        {
            if (provinceId == null)
            {
                TempData["ProvinceNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var entity = await _provinceService.GetWithDistrictsByIdAsync(Convert.ToInt32(provinceId));
            if (entity != null)
            {
                var model = new ProvinceEditViewModel
                {
                    Id = entity.Id,
                    NameTR = entity.NameTR,
                    NameEN = entity.NameEN,
                    Districts = entity.District.OrderByDescending(x => x.CreatedDate).Select(x => new DistrictListViewModel
                    {
                        Id = x.Id,
                        DistrictNameTR = x.DistrictNameTR,
                        DistrictNameEN = x.DistrictNameEN
                    }).ToList(),
                };

                return View(model);
            }

            TempData["ProvinceNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProvinceEditViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Edit), new { provinceId = model.Id });

            var entity = await _provinceService.GetByIdAsync(model.Id);
            if (entity != null)
            {
                entity.NameTR = model.NameTR;
                entity.NameEN = model.NameEN;

                var result = await _provinceService.EditAsync(entity);
                if (result)
                {
                    TempData["EditProvinceMessage"] = Messages.EDIT_SUCCESSFULLY_MESSAGE;
                    return RedirectToAction(nameof(Edit), new { provinceId = model.Id });
                }
            }

            TempData["ProvinceNotFound"] = Messages.NOT_FOUND_ERROR;
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? provinceId)
        {
            if (provinceId == null)
            {
                TempData["ProvinceNotFound"] = Messages.NOT_FOUND_ERROR;
                return RedirectToAction(nameof(List));
            }

            var result = await _provinceService.DeleteByIdAsync(Convert.ToInt32(provinceId));
            if (result == DeleteResponse.Success)
            {
                TempData["ProvinceDeleteMessage"] = Messages.DELETED_SUCCESSFULLY_MESSAGE;
                return RedirectToAction(nameof(List));
            }
            else if (result == DeleteResponse.InUse)
            {
                TempData["ProvinceIsUseError"] = Messages.CITY_DELETE_ERROR;
                return RedirectToAction(nameof(Edit), new { provinceId = provinceId });
            }

            TempData["ProvinceDeleteError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return RedirectToAction(nameof(List));
        }
    }
}