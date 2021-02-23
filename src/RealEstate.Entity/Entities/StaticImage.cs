using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("static_image")]
    public class StaticImage : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomId { get; set; }

        [Required]
        [StringLength(3)]
        public string Sort { get; set; }
    }
}