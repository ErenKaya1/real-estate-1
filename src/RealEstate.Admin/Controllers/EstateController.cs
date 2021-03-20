using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Common.Functions.Extensions;
using src.RealEstate.Admin.Models.Estate;
using src.RealEstate.Common.Constants;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Service.Contracts;

namespace src.RealEstate.Admin.Controllers
{
    [Authorize]
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IStaticImageService _staticImageService;
        private readonly IPanoramicImageService _panoramicImageService;
        private readonly IInteriorPropertyService _interiorPropertyService;
        private readonly IExternalPropertyService _externalPropertyService;
        private readonly IAmbitPropertyService _ambitPropertyService;
        private readonly ITransportationPropertyService _transportationPropertyService;

        public EstateController(IEstateService estateService,
                                IStaticImageService staticImageService, 
                                IPanoramicImageService panoramicImageService,
                                IInteriorPropertyService interiorPropertyService,
                                IExternalPropertyService externalPropertyService,
                                IAmbitPropertyService ambitPropertyService,
                                ITransportationPropertyService transportationPropertyService)
        {
            _estateService = estateService;
            _staticImageService = staticImageService;
            _panoramicImageService = panoramicImageService;
            _interiorPropertyService = interiorPropertyService;
            _externalPropertyService = externalPropertyService;
            _ambitPropertyService = ambitPropertyService;
            _transportationPropertyService = transportationPropertyService;
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
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
                await _staticImageService.AddRangeAsync(model.StaticImage, id.ToString(), model.StaticImageOrder);
                await _panoramicImageService.AddRangeAsync(model.PanoramicImage, id.ToString(), model.PanoramicImageOrder);

                var interiorProperties = model.CheckBoxes["InteriorProperties"].ToList();
                var externalProperties = model.CheckBoxes["ExternalProperties"].ToList();
                var ambitProperties = model.CheckBoxes["AmbitProperties"].ToList();
                var transportationProperties = model.CheckBoxes["TransportationProperties"].ToList();

                var estateInteriorProperties = new List<EstateInteriorProperty>();
                var estateExternalProperties = new List<EstateExternalProperty>();
                var estateAmbitProperties = new List<EstateAmbitProperty>();
                var estateTransportationProperties = new List<EstateTransportationProperty>();

                foreach (var property in interiorProperties)
                {
                    estateInteriorProperties.Add(new EstateInteriorProperty
                    {
                        EstateId = id,
                        InteriorPropertyId = int.Parse(property)
                    });
                }

                foreach (var property in externalProperties)
                {
                    estateExternalProperties.Add(new EstateExternalProperty
                    {
                        EstateId = id,
                        ExternalPropertyId = int.Parse(property)
                    });
                }

                foreach (var property in ambitProperties)
                {
                    estateAmbitProperties.Add(new EstateAmbitProperty
                    {
                        EstateId = id,
                        AmbitPropertyId = int.Parse(property)
                    });
                }

                foreach (var property in transportationProperties)
                {
                    estateTransportationProperties.Add(new EstateTransportationProperty
                    {
                        EstateId = id,
                        TransportationPropertyId = int.Parse(property)
                    }) ;
                }

                await _interiorPropertyService.AddEstateInteriorPropertyAsync(estateInteriorProperties);
                await _externalPropertyService.AddEstateExternalPropertyAsync(estateExternalProperties);
                await _ambitPropertyService.AddEstateAmbitPropertyAsync(estateAmbitProperties);
                await _transportationPropertyService.AddEstateTransportationPropertyAsync(estateTransportationProperties);

                return RedirectToAction("List");
            }
            else if (result == SaveResult.Duplicated)
            {
                ViewData["NewEstateError"] = Messages.DUPLICATED_DATA_ERROR;
                return View(model);
            }

            ViewData["NewEstateError"] = Messages.DEFAULT_ERROR_MESSAGE;
            return View(model);
        }
    }
}