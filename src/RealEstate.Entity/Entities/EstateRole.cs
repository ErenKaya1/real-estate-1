using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace src.RealEstate.Entity.Entities
{
    [Table("role")]
    public class EstateRole : IdentityRole<Guid>
    {
        
    }
}