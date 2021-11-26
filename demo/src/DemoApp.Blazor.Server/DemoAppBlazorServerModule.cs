using Abp.AspNetCore.Blazor.Theme.Bootstrap;
using Volo.Abp.Modularity;

namespace DemoApp.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapServerModule),
        typeof(DemoAppBlazorModule)
        )]
    public class DemoAppBlazorServerModule : AbpModule
    {
        
    }
}