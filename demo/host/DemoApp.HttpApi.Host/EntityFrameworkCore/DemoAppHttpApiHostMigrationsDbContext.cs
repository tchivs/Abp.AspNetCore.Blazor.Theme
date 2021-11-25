using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DemoApp.EntityFrameworkCore
{
    public class DemoAppHttpApiHostMigrationsDbContext : AbpDbContext<DemoAppHttpApiHostMigrationsDbContext>
    {
        public DemoAppHttpApiHostMigrationsDbContext(DbContextOptions<DemoAppHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureDemoApp();
        }
    }
}
