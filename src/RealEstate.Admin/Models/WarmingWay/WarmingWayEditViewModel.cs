using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.WarmingWay
{
    [Bind(nameof(Id), nameof(WarmingWayNameTR), nameof(WarmingWayNameEN))]
    public class WarmingWayEditViewModel
    {
        [Required]
        public int Id { get; set; }        

        [Required]
        [StringLength(30)]
        [Display(Name = "Isınma Yolu (Türkçe)")]
        public string WarmingWayNameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Isınma Yolu (İngilizce)")]
        public string WarmingWayNameEN { get; set; }
    }
}