using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace DemoApp.Blazor.WebAssembly
{
    [DependsOn(
        typeof(DemoAppBlazorModule),
        typeof(DemoAppHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class DemoAppBlazorWebAssemblyModule : AbpModule
    {
        
    }
}