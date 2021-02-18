using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.InteriorProperty
{
    [Bind(nameof(Id), nameof(PropertyNameTR), nameof(PropertyNameEN))]
    public class InteriorPropertyEditViewModel
    {
        [Required]
        public int Id { get; set; }

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