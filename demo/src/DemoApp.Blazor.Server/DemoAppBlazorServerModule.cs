using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace DemoApp.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(DemoAppBlazorModule)
        )]
    public class DemoAppBlazorServerModule : AbpModule
    {
        
    }
}