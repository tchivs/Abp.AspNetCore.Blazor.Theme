using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DemoApp.EntityFrameworkCore
{
    public class DemoAppModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DemoAppModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}