using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace DemoApp.MongoDB
{
    public static class DemoAppMongoDbContextExtensions
    {
        public static void ConfigureDemoApp(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DemoAppMongoModelBuilderConfigurationOptions(
                DemoAppDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}