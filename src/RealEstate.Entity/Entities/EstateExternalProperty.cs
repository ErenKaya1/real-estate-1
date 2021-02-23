using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate_external_property")]
    public class EstateExternalProperty
    {
        [Required]
        public int EstateId { get; set; }

        [Required]
        public int ExternalPropertyId { get; set; }

        public Estate Estate { get; set; }
        public ExternalProperty ExternalProperty { get; set; }
    }
}