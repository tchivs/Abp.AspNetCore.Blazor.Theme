using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.Features;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap;

namespace Tchivs.Abp.FeatureManagement.Bootstrap.Blazor
{

    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpFeaturesModule)
    )]
    public class TchivsAbpFeatureManagementBootstrapBlazorModule : AbpModule
    {

    }

}