using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoApp.EntityFrameworkCore
{
    public class DemoAppHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<DemoAppHttpApiHostMigrationsDbContext>
    {
        public DemoAppHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DemoAppHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DemoApp"));

            return new DemoAppHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
