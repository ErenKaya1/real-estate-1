using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("transportation_property")]
    public class TransportationProperty : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string PropertyNameTR { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyNameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
    }
}