using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("district")]
    public class District : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string DistrictNameTR { get; set; }

        [Required]
        [StringLength(30)]
        public string DistrictNameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        public List<Estate> Estate { get; set; }
        public Province Province { get; set; }
    }
}