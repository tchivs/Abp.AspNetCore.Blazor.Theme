using Abp.AspNetCore.Blazor.Theme.Bootstrap;
using Volo.Abp.Modularity;

namespace DemoApp.Blazor.WebAssembly
{
    [DependsOn(
        typeof(DemoAppBlazorModule),
        typeof(DemoAppHttpApiClientModule),
        typeof(AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule)
        )]
    public class DemoAppBlazorWebAssemblyModule : AbpModule
    {
        
    }
}