using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate")]
    public class Estate : BaseEntity
    {
        public string CustomId { get; set; }
        public string Title { get; set; }
        public string UrlPath { get; set; }
        public double PriceTRY { get; set; }
        public string M2 { get; set; }
        public string RoomCount { get; set; }
        public string FloorNumber { get; set; }
        public string TotalFloor { get; set; }
        public BuildingStatus BuildingStatus { get; set; }
        public SaleType SaleType { get; set; }
        public string BuildingAge { get; set; }
        public int WarmingWayId { get; set; }
        public AvailableForLoan AvailableForLoan { get; set; }
        public FurnitureStatus FurnitureStatus { get; set; }
        public string BathroomCount { get; set; }
        public BuildingState BuildingState { get; set; }
        public int BuildingTypeId { get; set; }
        public int TitleDeedStatusId { get; set; }
        public UsingStatus UsingStatus { get; set; }
        public AvailableForTrade AvailableForTrade { get; set; }
        public Facade Facade { get; set; }
        public string DescriptionTR { get; set; }
        public string DescriptionEN { get; set; }
        public int EstateTypeId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string GoogleMapIframe { get; set; }

        public List<StaticImage> StaticImage { get; set; }
        public List<PanoramicImage> PanoramicImage { get; set; }
        public List<EstateInteriorProperty> EstateInteriorProperty { get; set; }
        public List<EstateExternalProperty> EstateExternalProperty { get; set; }
        public List<EstateAmbitProperty> EstateAmbitProperty { get; set; }
        public List<EstateTransportationProperty> EstateTransportationProperty { get; set; }
        public WarmingWay WarmingWay { get; set; }
        public BuildingType BuildingType { get; set; }
        public TitleDeedStatus TitleDeedStatus { get; set; }
        public EstateType EstateType { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
    }
}