using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("warming_way")]
    public class WarmingWay : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string WarmingWayNameTR { get; set; }

        [Required]
        [StringLength(30)]
        public string WarmingWayNameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
    }
}