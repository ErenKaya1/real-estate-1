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
    }
}