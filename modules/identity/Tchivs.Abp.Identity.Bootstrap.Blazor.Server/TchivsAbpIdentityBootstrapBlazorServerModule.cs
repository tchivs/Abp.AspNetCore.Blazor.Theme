using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchivs.Abp.Identity.Bootstrap.Blazor;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.Identity.Bootstrap.Blazor.Server
{
    [DependsOn(
        typeof(TchivsAbpIdentityBootstrapBlazorModule),
      typeof(Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.AbpAspNetCoreBlazorThemeBootstrapServerModule)
        )]
    public class TchivsAbpIdentityBootstrapBlazorServerModule : AbpModule
    {

    }
}
