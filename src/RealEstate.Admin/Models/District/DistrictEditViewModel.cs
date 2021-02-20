using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.District
{
    [Bind(nameof(ProvinceId), nameof(DistrictId), nameof(DistrictNameTR), nameof(DistrictNameEN))]
    public class DistrictEditViewModel
    {
        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "İlçe Adı (Türkçe)")]
        public string DistrictNameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "İlçe Adı (İngilizce)")]
        public string DistrictNameEN { get; set; }
    }
}