using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using src.RealEstate.Admin.Models.District;

namespace src.RealEstate.Admin.Models.Province
{
    [Bind(nameof(Id), nameof(NameTR), nameof(NameEN), nameof(DistrictNameTR), nameof(DistrictNameEN))]
    public class ProvinceEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "İl Adı (Türkçe)")]
        public string NameTR { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "İl Adı (İngilizce)")]
        public string NameEN { get; set; }

        [StringLength(30)]
        [Display(Name = "İlçe Adı (Türkçe)")]
        public string DistrictNameTR { get; set; }

        [StringLength(30)]
        [Display(Name = "İlçe Adı (İngilizce)")]
        public string DistrictNameEN { get; set; }

        public List<DistrictListViewModel> Districts { get; set; }
    }
}