using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace DemoApp.MongoDB
{
    public class DemoAppMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DemoAppMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}