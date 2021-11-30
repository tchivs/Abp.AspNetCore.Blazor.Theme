using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.FeatureManagement.Bootstrap.Blazor.WebAssembly
{
    [DependsOn(
        typeof(TchivsAbpFeatureManagementBootstrapBlazorModule),
           typeof(AbpFeatureManagementHttpApiClientModule),
      typeof(Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule)
        )]
    public class TchivsAbpFeatureManagementBootstrapBlazorWebAssemblyModule : AbpModule
    {

    }
}
