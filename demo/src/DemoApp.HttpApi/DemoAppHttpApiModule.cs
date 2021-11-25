using Localization.Resources.AbpUi;
using DemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DemoAppHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DemoAppHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DemoAppResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
