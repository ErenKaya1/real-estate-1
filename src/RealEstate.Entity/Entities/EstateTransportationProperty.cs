using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.RealEstate.Entity.Entities
{
    [Table("estate_transportation_property")]
    public class EstateTransportationProperty
    {
        [Required]
        public int EstateId { get; set; }

        [Required]
        public int TransportationPropertyId { get; set; }

        public Estate Estate { get; set; }
        public TransportationProperty TransportationProperty { get; set; }
    }
}