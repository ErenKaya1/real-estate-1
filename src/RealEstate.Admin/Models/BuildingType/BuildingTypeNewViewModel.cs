using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.BuildingType
{
    [Bind(nameof(BuildingTypeNameTR), nameof(BuildingTypeNameEN))]
    public class BuildingTypeNewViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Yapı Türü (Türkçe)")]
        public string BuildingTypeNameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Yapı Türü (İngilizce)")]
        public string BuildingTypeNameEN { get; set; }
    }
}