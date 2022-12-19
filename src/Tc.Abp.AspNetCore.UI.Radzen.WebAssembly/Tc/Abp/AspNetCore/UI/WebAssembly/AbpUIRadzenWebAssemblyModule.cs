using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.WebAssembly;
using Tc.Abp.AspNetCore.Toolbars;
using Tchivs.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;
using Volo.Abp.Modularity;

namespace Tc.Abp.AspNetCore.UI.WebAssembly;
[DependsOn(typeof(TcAbpAspNetCoreComponentsWebAssemblyModule))]
public class TcAbpUIMudBlazorWebAssemblyModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(GetType().Assembly);
        });
        Configure<AbpToolbarOptions>(options =>
       {
           options.Contributors.Add(new RadzenWebAssemblyThemeToolbarContributor());
       });
    }
}


