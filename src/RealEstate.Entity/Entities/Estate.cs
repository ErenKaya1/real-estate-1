using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Common.Enum;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate")]
    public class Estate : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string CustomId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string UrlPath { get; set; }

        [Required]
        public double PriceTRY { get; set; }

        [Required]
        [StringLength(20)]
        public string M2 { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomCount { get; set; }

        [Required]
        [StringLength(3)]
        public string FloorNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string TotalFloor { get; set; }

        [Required]
        public BuildingStatus BuildingStatus { get; set; }

        [Required]
        public SaleType SaleType { get; set; }

        [Required]
        [StringLength(5)]
        public string BuildingAge { get; set; }

        [Required]
        public int WarmingWayId { get; set; }

        [Required]
        public AvailableForLoan AvailableForLoan { get; set; }

        [Required]
        public FurnitureStatus FurnitureStatus { get; set; }

        [Required]
        [StringLength(2)]
        public string BathroomCount { get; set; }

        [Required]
        public BuildingState BuildingState { get; set; }

        [Required]
        public int BuildingTypeId { get; set; }

        [Required]
        public int TitleDeedStatusId { get; set; }

        [Required]
        public UsingStatus UsingStatus { get; set; }

        [Required]
        public AvailableForTrade AvailableForTrade { get; set; }

        [Required]
        public Facade Facade { get; set; }

        [Required]
        public string DescriptionTR { get; set; }

        [Required]
        public string DescriptionEN { get; set; }

        [Required]
        public int EstateTypeId { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(500)]
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