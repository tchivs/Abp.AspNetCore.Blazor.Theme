using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.Features;
namespace Tchivs.Abp.FeatureManagement.Bootstrap.Blazor
{

    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpFeaturesModule)
    )]
    public class TchivsAbpFeatureManagementBootstrapBlazorModule : AbpModule
    {

    }

}