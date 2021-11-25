using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoApp.EntityFrameworkCore
{
    [ConnectionStringName(DemoAppDbProperties.ConnectionStringName)]
    public class DemoAppDbContext : AbpDbContext<DemoAppDbContext>, IDemoAppDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDemoApp();
        }
    }
}