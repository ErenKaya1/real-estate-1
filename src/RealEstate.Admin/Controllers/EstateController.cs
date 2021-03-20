using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Common.Functions.Extensions;
using src.RealEstate.Admin.Models.Estate;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(EstateNewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Estate
            {
                CustomId = model.CustomId,
                TitleTR = model.TitleTR,
                TitleEN = model.TitleEN,
                UrlPathTR = model.TitleTR.ToSlug(),
                UrlPathEN = model.TitleEN.ToSlug(),
                PriceTRY = model.PriceTRY,
                M2Brut = model.M2Brut,
                M2Net = model.M2Net,
                RoomCount = model.RoomCount,
                FloorNumber = model.FloorNumber,
                TotalFloor = model.TotalFloor,
                BuildingStatus = model.BuildingStatus,
                SaleType = model.SaleType,
                BuildingAge = model.BuildingAge,
                WarmingWayId = model.WarmingWayId,
                AvailableForLoan = model.AvailableForLoan,
                FurnitureStatus = model.FurnitureStatus,
                BathroomCount = model.BathroomCount,
                BuildingState = model.BuildingState,
                BuildingTypeId = model.BuildingTypeId,
                TitleDeedStatusId = model.TitleDeedStatusId,
                UsingStatus = model.UsingStatus,
                AvailableForTrade = model.AvailableForTrade,
                Facade = model.Facade,
                DescriptionTR = model.DescriptionTR,
                DescriptionEN = model.DescriptionEN,
                EstateTypeId = model.EstateTypeId,
                ProvinceId = model.ProvinceId,
                DistrictId = model.DistrictId,
                CreatedDate = DateTime.Now.Date,
                GoogleMapIframe = model.GoogleMapIframe,
            };

            var (result, id) = await _estateService.AddOneAsync(entity);
            if (result == SaveResult.Success)
            {
                var staticImages = new List<StaticImage>();
                var panoramicImages = new List<PanoramicImage>();
                var staticOrders = string.IsNullOrEmpty(model.StaticImageOrder) ? new List<string>() : model.StaticImageOrder.Split(';').ToList();
                var panoramicOrders = string.IsNullOrEmpty(model.PanoramicImageOrder) ? new List<string>() : model.PanoramicImageOrder.Split(';').ToList();
                int order = 0;

                foreach (var image in model.StaticImage)
                {
                    if (!image.IsImage()) continue;
                    order = staticOrders.Count == 0 ? 0 : staticOrders.IndexOf(staticOrders.First(x => x == image.FileName));
                    staticImages.Add(new StaticImage
                    {
                        ImageName = image.FileName,
                        Order = order,
                    });
                }

                foreach (var image in model.PanoramicImage)
                {
                    if (!image.IsImage()) continue;
                    order = panoramicOrders.Count == 0 ? 0 : panoramicOrders.IndexOf(panoramicOrders.First(x => x == image.FileName));
                    panoramicImages.Add(new PanoramicImage
                    {
                        ImageName = image.FileName,
                        Order = order
                    });
                }
            }

            return NotFound();

            //var interiorProperties = model.CheckBoxes["InteriorProperties"].ToList();
            //var externalProperties = model.CheckBoxes["ExternalProperties"].ToList();
            //var ambitProperties = model.CheckBoxes["AmbitProperties"].ToList();
            //var transportationProperties = model.CheckBoxes["TransportationProperties"].ToList();
        }
    }
}