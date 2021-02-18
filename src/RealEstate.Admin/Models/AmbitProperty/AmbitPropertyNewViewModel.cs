using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.AmbitProperty
{
    [Bind(nameof(PropertyNameTR), nameof(PropertyNameEN))]
    public class AmbitPropertyNewViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Özellik Adı (Türkçe)")]
        public string PropertyNameTR { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Özellik Adı (İngilizce)")]
        public string PropertyNameEN { get; set; }
    }
}