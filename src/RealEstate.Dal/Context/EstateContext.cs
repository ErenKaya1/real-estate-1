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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Estate>().HasIndex(x => x.CustomId).IsUnique();
            builder.Entity<Estate>().HasIndex(x => x.Title).IsUnique();
            builder.Entity<Estate>().HasIndex(x => x.UrlPath).IsUnique();
            //builder.Entity<Estate>().HasOne(x => x.District).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Estate>().HasOne(x => x.Province).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Estate>().HasOne(x => x.BuildingType).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Estate>().HasOne(x => x.EstateType).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Estate>().HasOne(x => x.TitleDeedStatus).WithMany().OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Estate>().HasOne(x => x.WarmingWay).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<EstateInteriorProperty>().HasKey(x => new { x.EstateId, x.InteriorPropertyId });
            builder.Entity<EstateExternalProperty>().HasKey(x => new { x.EstateId, x.ExternalPropertyId });
            builder.Entity<EstateAmbitProperty>().HasKey(x => new { x.EstateId, x.AmbitPropertyId });
            builder.Entity<EstateTransportationProperty>().HasKey(x => new { x.EstateId, x.TransportationPropertyId });
            base.OnModelCreating(builder);
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
        public DbSet<EstateType> EstateType { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<WarmingWay> WarmingWay { get; set; }
        public DbSet<BuildingType> BuildingType { get; set; }
        public DbSet<TitleDeedStatus> TitleDeedStatus { get; set; }
        public DbSet<StaticImage> StaticImage { get; set; }
        public DbSet<PanoramicImage> PanoramicImage { get; set; }
        public DbSet<EstateInteriorProperty> EstateInteriorProperty { get; set; }
        public DbSet<EstateExternalProperty> EstateExternalProperty { get; set; }
        public DbSet<EstateAmbitProperty> EstateAmbitProperty { get; set; }
        public DbSet<EstateTransportationProperty> EstateTransportationProperty { get; set; }
        public DbSet<Estate> Estate { get; set; }
    }
}