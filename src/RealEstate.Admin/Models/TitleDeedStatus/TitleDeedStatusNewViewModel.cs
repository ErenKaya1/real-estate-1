using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.TitleDeedStatus
{
    [Bind(nameof(StatusNameTR), nameof(StatusNameEN))]
    public class TitleDeedStatusNewViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Tapu Durumu (Türkçe)")]
        public string StatusNameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tapu Durumu (İngilizce)")]
        public string StatusNameEN { get; set; }
    }
}