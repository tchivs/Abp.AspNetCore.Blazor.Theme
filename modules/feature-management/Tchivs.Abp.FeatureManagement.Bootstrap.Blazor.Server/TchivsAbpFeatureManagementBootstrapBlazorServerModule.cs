using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.FeatureManagement.Bootstrap.Blazor.Server
{
    [DependsOn(
        typeof(TchivsAbpFeatureManagementBootstrapBlazorModule),
      typeof(Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.AbpAspNetCoreBlazorThemeBootstrapServerModule)
        )]
    public class TchivsAbpFeatureManagementBootstrapBlazorServerModule : AbpModule
    {

    }
}
