using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Dal.Context
{
    public class EstateContext : IdentityDbContext<EstateUser, EstateRole, Guid>
    {
        public EstateContext(DbContextOptions<EstateContext> options) : base(options)
        {

        }
    }
}