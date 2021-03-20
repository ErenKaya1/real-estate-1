using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using src.RealEstate.Entity.Entities.Base;

namespace src.RealEstate.Entity.Entities
{
    [Table("panoramic_image")]
    public class PanoramicImage : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int EstateId { get; set; }

        public Estate Estate { get; set; }
    }
}