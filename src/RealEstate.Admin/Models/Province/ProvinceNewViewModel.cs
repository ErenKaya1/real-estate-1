using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.Province
{
    [Bind(nameof(NameTR), nameof(NameEN))]
    public class ProvinceNewViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "İl Adı (Türkçe)")]
        public string NameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "İl Adı (İngilizce)")]
        public string NameEN { get; set; }
    }
}