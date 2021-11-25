using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoApp.EntityFrameworkCore
{
    [ConnectionStringName(DemoAppDbProperties.ConnectionStringName)]
    public interface IDemoAppDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}