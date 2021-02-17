using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.RealEstate.Entity.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}