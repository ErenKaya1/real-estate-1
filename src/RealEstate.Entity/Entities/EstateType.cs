using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate_type")]
    public class EstateType : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string TypeNameTR { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeNameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public List<Estate> Estate { get; set; }
    }
}