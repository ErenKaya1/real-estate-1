using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace src.RealEstate.Dal.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EstateContext>
    {
        public EstateContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EstateContext>();
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "../RealEstate.Admin");
            var configuration = new ConfigurationBuilder()
                                        .SetBasePath(configPath)
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            var connectionString = configuration.GetConnectionString("MySqlProvider");
            builder.UseMySql(connectionString);

            return new EstateContext(builder.Options);
        }
    }
}