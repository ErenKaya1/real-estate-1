using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate_interior_property")]
    public class EstateInteriorProperty
    {
        [Required]
        public int EstateId { get; set; }

        [Required]
        public int InteriorPropertyId { get; set; }

        public Estate Estate { get; set; }
        public InteriorProperty InteriorProperty { get; set; }
    }
}