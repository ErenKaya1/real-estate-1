using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.EstateType
{
    [Bind(nameof(Id), nameof(TypeNameTR), nameof(TypeNameEN))]
    public class EstateTypeEditViewModel
    {
        [Required]
        public int Id { get; set; }

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