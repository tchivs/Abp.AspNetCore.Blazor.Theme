using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DemoApp.MongoDB
{
    [ConnectionStringName(DemoAppDbProperties.ConnectionStringName)]
    public class DemoAppMongoDbContext : AbpMongoDbContext, IDemoAppMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDemoApp();
        }
    }
}