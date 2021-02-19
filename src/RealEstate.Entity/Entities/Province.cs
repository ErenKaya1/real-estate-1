using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("province")]
    public class Province : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string NameTR { get; set; }

        [Required]
        [StringLength(30)]
        public string NameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }
    }
}