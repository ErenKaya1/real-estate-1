using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.EstateType
{
    [Bind(nameof(TypeNameTR), nameof(TypeNameEN))]
    public class EstateTypeNewViewModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Tür Adı (Türkçe)")]
        public string TypeNameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tür Adı (İngilizce)")]
        public string TypeNameEN { get; set; }
    }
}