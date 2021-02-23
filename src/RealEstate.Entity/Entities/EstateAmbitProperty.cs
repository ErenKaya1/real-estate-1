using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate_ambit_property")]
    public class EstateAmbitProperty
    {
        [Required]
        public int EstateId { get; set; }

        [Required]
        public int AmbitPropertyId { get; set; }

        public Estate Estate { get; set; }
        public AmbitProperty AmbitProperty { get; set; }
    }
}