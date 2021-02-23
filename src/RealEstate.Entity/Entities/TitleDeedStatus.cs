using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("title_deed_status")]
    public class TitleDeedStatus : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string StatusNameTR { get; set; }

        [Required]
        [StringLength(30)]
        public string StatusNameEN { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public List<Estate> Estate { get; set; }
    }
}