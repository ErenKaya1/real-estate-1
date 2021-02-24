using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using src.RealEstate.Common.Enum;

namespace src.RealEstate.Admin.Models.Estate
{
    // Bind attibute eklenecek.
    public class EstateNewViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "ID")]
        public string CustomId { get; set; }//

        [Required]
        [StringLength(200)]
        [Display(Name = "Başlık (Türkçe)")]
        public string TitleTR { get; set; }//

        [Required]
        [StringLength(200)]
        [Display(Name = "Başlık (İngilizce)")]
        public string TitleEN { get; set; }//

        [Required]
        [Display(Name = "Fiyat (₺)")]
        public double PriceTRY { get; set; }//

        [Required]
        [StringLength(20)]
        [Display(Name = "M2 (Brüt)")]
        public string M2Brut { get; set; }//

        [Required]
        [StringLength(20)]
        [Display(Name = "M2 (Net)")]
        public string M2Net { get; set; }//

        [Required]
        [StringLength(10)]
        [Display(Name = "Oda Sayısı (2+1)")]
        public string RoomCount { get; set; }//

        [Required]
        [StringLength(3)]
        [Display(Name = "Kat Numarası")]
        public string FloorNumber { get; set; }//

        [Required]
        [StringLength(5)]
        [Display(Name = "Toplam Kat Sayısı")]
        public string TotalFloor { get; set; }//

        [Required]
        [Display(Name = "Bina Durumu")]
        public BuildingStatus BuildingStatus { get; set; }//

        [Required]
        [Display(Name = "Satış Tipi")]
        public SaleType SaleType { get; set; }//

        [Required]
        [StringLength(5)]
        [Display(Name = "Bina Yaşı")]
        public string BuildingAge { get; set; }//

        [Required]
        [Display(Name = "Isınma Şekli")]
        public int WarmingWayId { get; set; }

        [Required]
        [Display(Name = "Krediye Uygunluk")]
        public AvailableForLoan AvailableForLoan { get; set; }//

        [Required]
        [Display(Name = "Eşya Durumu")]
        public FurnitureStatus FurnitureStatus { get; set; }//

        [Required]
        [StringLength(2)]
        [Display(Name = "Banyo Sayısı")]
        public string BathroomCount { get; set; }//

        [Required]
        [Display(Name = "Yapı Durumu")]
        public BuildingState BuildingState { get; set; }//

        [Required]
        [Display(Name = "Yapı Tipi")]
        public int BuildingTypeId { get; set; }//

        [Required]
        [Display(Name = "Tapu Durumu")]
        public int TitleDeedStatusId { get; set; }

        [Required]
        [Display(Name = "Kullanım Durumu")]
        public UsingStatus UsingStatus { get; set; }//

        [Required]
        [Display(Name = "Takasa Uygunluk")]
        public AvailableForTrade AvailableForTrade { get; set; }//

        [Required]
        [Display(Name = "Cephe")]
        public Facade Facade { get; set; }//

        [Required]
        [Display(Name = "Açıklama (Türkçe)")]
        public string DescriptionTR { get; set; }

        [Required]
        [Display(Name = "Açıklama (İngilizce)")]
        public string DescriptionEN { get; set; }

        [Required]
        [Display(Name = "Emlak Tipi")]
        public int EstateTypeId { get; set; }

        [Required]
        [Display(Name = "İl")]
        public int ProvinceId { get; set; }//

        [Required]
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }//

        [Required]
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }//

        [Required]
        [StringLength(500)]
        [Display(Name = "Google Map Iframe")]
        public string GoogleMapIframe { get; set; }
        
        [Display(Name = "Static Fotoğraflar")]
        public List<IFormFile> StaticImage { get; set; }

        [Display(Name = "Panoramik Fotoğraflar")]
        public List<IFormFile> PanoramicImage { get; set; }
    }
}