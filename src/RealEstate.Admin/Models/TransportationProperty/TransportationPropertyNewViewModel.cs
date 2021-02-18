using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.TransportationProperty
{
    [Bind(nameof(PropertyNameTR), nameof(PropertyNameEN))]
    public class TransportationPropertyNewViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Özellik Adı (Türkçe)")]
        public string PropertyNameTR { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Özellik Adı (Türkçe)")]
        public string PropertyNameEN { get; set; }
    }
}