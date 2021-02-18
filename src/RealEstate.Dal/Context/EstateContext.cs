using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.RealEstate.Entity.Entities;

namespace src.RealEstate.Dal.Context
{
    public class EstateContext : IdentityDbContext<EstateUser, EstateRole, Guid>
    {
        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public EstateContext(DbContextOptions<EstateContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<InteriorProperty> InteriorProperty { get; set; }
        public DbSet<ExternalProperty> ExternalProperty { get; set; }
        public DbSet<AmbitProperty> AmbitProperty { get; set; }
        public DbSet<TransportationProperty> TransportationProperty { get; set; }
    }
}